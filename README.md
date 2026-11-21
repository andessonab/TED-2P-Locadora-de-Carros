# TED – Locadora de Carros

**Curso:** Sistemas de Informação – 2º período  
**Disciplina:** Estruturas de Dados  
**Professora:** Rosângela  
**Instituição:** UNISAPIENS  
**Grupo:** 5

**Integrantes**
- Carlos Henrique Farias dos Santos
- Andesson Albano
- Elias de Souza

## Sobre o trabalho

Neste trabalho, fizemos um programa simples de locadora de carros em C#. A ideia foi usar os algoritmos estudados na disciplina em uma situação que fosse fácil de entender.

O programa começa com oito carros cadastrados. Pelo menu, é possível listar os veículos, procurar um modelo ou um ID, organizar os carros por preço ou ano, encontrar o mais barato e o mais caro disponíveis, alugar e devolver um veículo.

Para guardar os carros, usamos uma lista do tipo `List<Carro>`. Os dados ficam na memória enquanto o programa está aberto: ao fechar e executar novamente, os oito carros voltam à situação inicial.

## Algoritmos utilizados

| Tipo | Algoritmo | Uso no programa |
|---|---|---|
| Ordenação | Bubble Sort | Organiza os carros pela diária, da menor para a maior. |
| Ordenação | Insertion Sort | Organiza os carros pelo ano, do mais antigo para o mais novo. |
| Busca | Busca sequencial | Procura um carro pelo modelo, mesmo digitando apenas parte do nome. |
| Busca | Busca binária | Procura um carro pelo ID. |
| Seleção | Menor valor | Mostra o carro disponível com a diária mais barata. |
| Seleção | Maior valor | Mostra o carro disponível com a diária mais cara. |

Nas duas ordenações, usamos uma cópia da lista. Assim, a lista principal continua organizada por ID, como a busca binária precisa.

## Opções do menu

| Opção | O que faz |
|---|---|
| 1 | Lista os carros cadastrados. |
| 2 | Ordena por diária (Bubble Sort). |
| 3 | Ordena por ano (Insertion Sort). |
| 4 | Busca pelo modelo (sequencial). |
| 5 | Busca pelo ID (binária). |
| 6 | Mostra o carro disponível mais barato. |
| 7 | Mostra o carro disponível mais caro. |
| 8 | Aluga um carro. |
| 9 | Devolve um carro. |
| 0 | Encerra o programa. |

## Como executar

O projeto é um aplicativo de console. Para executar, é necessário ter o **.NET 8 SDK** instalado.

No terminal, dentro da pasta do projeto, digite:

```bash
dotnet run
```

No Visual Studio, também é possível abrir o arquivo `LocadoraCarros.csproj` e iniciar o programa.

### Exemplo de teste

1. Abra a opção **1** para ver os oito carros e seus IDs.
2. Use as opções **2** e **3** para conferir a ordenação por diária e por ano.
3. Na opção **4**, digite `HB20` para procurar o Hyundai HB20.
4. Na opção **5**, digite `4` para encontrar o Volkswagen Polo.
5. Na opção **8**, escolha o carro de ID `5` (Toyota Corolla), informe o nome de um cliente e `15` dias. O valor calculado deve ser **R$ 2.848,50**.
6. Tente alugar o ID `5` novamente. O programa deve avisar que o carro já está alugado.
7. Na opção **9**, devolva o carro de ID `5`.

## Arquivos e documentação

- `Program.cs` – código-fonte da locadora.
- `LocadoraCarros.csproj` – configuração do projeto em C#.
- `README.md` – apresentação do projeto e instruções para executar.
- [Roteiro de testes](docs/ROTEIRO_DE_TESTES.md) – exemplos para conferir o funcionamento.
- `tests/test_console.py` – testes automáticos.
- `.github/workflows/build.yml` – configuração da compilação e dos testes.

O relatório escrito do grupo tem oito páginas e apresenta a introdução, o objetivo, o desenvolvimento, a conclusão e as capturas de execução. O PDF original foi preservado, sem alterações.

## Conferência do funcionamento

Além dos testes manuais apresentados no relatório, configuramos uma verificação pelo GitHub Actions. Ela compila o programa com .NET 8 e executa **18 testes automáticos**, incluindo busca, ordenação, aluguel e devolução.

O resultado pode ser visto na aba **Ações** do repositório.

## Conclusão

O projeto ajudou a entender como uma lista pode ser usada junto com diferentes algoritmos. Também mostrou uma diferença importante: ordenar por preço ou por ano não significa que podemos usar a busca binária nessa mesma ordem. Por isso, mantivemos a lista principal organizada pelo ID e fizemos as ordenações em cópias.

O programa é uma simulação para a disciplina, sem banco de dados ou histórico permanente de aluguéis. Essas seriam possibilidades para uma versão futura.
