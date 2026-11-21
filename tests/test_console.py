"""Testes funcionais simples para o aplicativo de console da locadora.

O GitHub Actions compila o projeto antes de executar estes testes.
Não há bibliotecas externas ou banco de dados.
"""
import re
import subprocess
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
DLL = ROOT / "bin" / "Release" / "net8.0" / "LocadoraCarros.dll"
CARRO = re.compile(
    r"(?m)^\s*(\d+)\s+(Fiat|Chevrolet|Hyundai|Volkswagen|Toyota|Honda|Jeep)"
    r"\s+(\S+)\s+(\d{4})\s+R\$\s+(\d+,\d{2})\s+"
    r"(Disponível|Alugado)"
)

def executar(entradas):
    if not DLL.is_file():
        raise AssertionError("Projeto não compilado: " + str(DLL))
    resposta = subprocess.run(
        ["dotnet", str(DLL)],
        input="\n".join(str(x) for x in entradas) + "\n",
        text=True,
        encoding="utf-8",
        errors="replace",
        capture_output=True,
        timeout=20,
        cwd=ROOT
    )
    if resposta.returncode != 0:
        raise AssertionError("Falha na execução: " + resposta.stderr)
    return resposta.stdout

def carros(saida):
    return CARRO.findall(saida)

class TestesLocadora(unittest.TestCase):
    def test_01_listar_oito_carros(self):
        linhas = carros(executar([1, 0]))
        self.assertEqual([int(x[0]) for x in linhas], list(range(1, 9)))

    def test_02_bubble_sort_diarias(self):
        linhas = carros(executar([2, 0]))
        self.assertEqual([int(x[0]) for x in linhas], [1, 3, 2, 4, 6, 5, 7, 8])

    def test_03_insertion_sort_ano(self):
        linhas = carros(executar([3, 0]))
        self.assertEqual([int(x[0]) for x in linhas], [4, 3, 6, 1, 7, 2, 5, 8])

    def test_04_busca_sequencial(self):
        linhas = carros(executar([4, "hb20", 0]))
        self.assertEqual([(int(c[0]), c[2]) for c in linhas], [(3, "HB20")])

    def test_05_busca_binaria_existente(self):
        linhas = carros(executar([5, 4, 0]))
        self.assertEqual([(int(c[0]), c[2]) for c in linhas], [(4, "Polo")])

    def test_06_busca_binaria_inexistente(self):
        self.assertIn("Carro não encontrado.", executar([5, 12, 0]))

    def test_07_selecao_mais_barato(self):
        linhas = carros(executar([6, 0]))
        self.assertEqual([(c[2], c[4]) for c in linhas], [("Mobi", "89,90")])

    def test_08_selecao_mais_caro(self):
        linhas = carros(executar([7, 0]))
        self.assertEqual([(c[2], c[4]) for c in linhas], [("Hilux", "329,00")])

    def test_09_aluguel_repetido_e_devolucao(self):
        saida = executar([8, 5, "Ana", 15, 8, 5, 9, 5, 0])
        self.assertIn("Toyota Corolla alugado para Ana. Total: R$ 2848,50", saida)
        self.assertIn("Esse carro já está alugado.", saida)
        self.assertIn("Toyota Corolla devolvido.", saida)

    def test_10_dias_invalidos_nao_alugam(self):
        saida = executar([8, 5, "Ana", 0, 1, 0])
        self.assertIn("Dados inválidos.", saida)
        linhas = carros(saida)
        self.assertEqual(next(x[5] for x in linhas if x[0] == "5"), "Disponível")

    def test_11_cliente_vazio(self):
        saida = executar([8, 5, "   ", 2, 0])
        self.assertIn("Dados inválidos.", saida)

    def test_12_modelo_vazio(self):
        self.assertIn("Digite um modelo válido.", executar([4, "", 0]))

    def test_13_opcao_invalida(self):
        self.assertIn("Opção inválida.", executar([99, 0]))

    def test_14_mantem_ordem_original(self):
        linhas = carros(executar([2, 3, 1, 0]))
        self.assertEqual([int(x[0]) for x in linhas[-8:]], list(range(1, 9)))

    def test_15_devolucao_sem_aluguel(self):
        self.assertIn("Esse carro não está alugado.", executar([9, 5, 0]))

    def test_16_valida_numero(self):
        saida = executar(["abc", 1, 0])
        self.assertIn("Número inválido.", saida)
        self.assertEqual(len(carros(saida)), 8)

    def test_17_nao_seleciona_alugado(self):
        saida = executar([8, 1, "Ana", 1, 6, 0])
        self.assertIn("Carro disponível mais barato:", saida)
        self.assertEqual(carros(saida)[0][2], "HB20")

    def test_18_sem_carros_disponiveis(self):
        entradas = []
        for i in range(1, 9):
            entradas.extend([8, i, "Cliente", 1])
        entradas.extend([6, 7, 0])
        saida = executar(entradas)
        self.assertEqual(saida.count("Não há carros disponíveis."), 2)

if __name__ == "__main__":
    unittest.main()
