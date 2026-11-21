using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LocadoraCarros
{
    class Carro
    {
        public int Id;
        public string Marca;
        public string Modelo;
        public int Ano;
        public double Diaria;
        public bool Disponivel = true;
        public string Cliente = "";
    }

    class Program
    {
        static List<Carro> frota = new List<Carro>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
            CarregarFrota();

            int opcao = -1;
            while (opcao != 0)
            {
                MostrarMenu();
                opcao = LerInteiro("Escolha uma opção: ");

                if (opcao == 1) ListarCarros(frota);
                else if (opcao == 2) OrdenarPorDiaria();
                else if (opcao == 3) OrdenarPorAno();
                else if (opcao == 4) BuscarPorModelo();
                else if (opcao == 5) BuscarPorId();
                else if (opcao == 6) MostrarMaisBarato();
                else if (opcao == 7) MostrarMaisCaro();
                else if (opcao == 8) AlugarCarro();
                else if (opcao == 9) DevolverCarro();
                else if (opcao != 0) Console.WriteLine("Opção inválida.");
            }

            Console.WriteLine("Programa encerrado.");
        }

        static void CarregarFrota()
        {
            AdicionarCarro("Fiat", "Mobi", 2023, 89.90);
            AdicionarCarro("Chevrolet", "Onix", 2024, 99.90);
            AdicionarCarro("Hyundai", "HB20", 2022, 94.50);
            AdicionarCarro("Volkswagen", "Polo", 2021, 109.00);
            AdicionarCarro("Toyota", "Corolla", 2024, 189.90);
            AdicionarCarro("Honda", "Civic", 2022, 179.00);
            AdicionarCarro("Jeep", "Compass", 2023, 249.90);
            AdicionarCarro("Toyota", "Hilux", 2024, 329.00);
        }

        static void AdicionarCarro(string marca, string modelo, int ano, double diaria)
        {
            Carro c = new Carro();
            c.Id = frota.Count + 1;
            c.Marca = marca;
            c.Modelo = modelo;
            c.Ano = ano;
            c.Diaria = diaria;
            frota.Add(c);
        }

        static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== LOCADORA DE CARROS =====");
            Console.WriteLine("1 - Listar carros");
            Console.WriteLine("2 - Ordenar por diária (Bubble Sort)");
            Console.WriteLine("3 - Ordenar por ano (Insertion Sort)");
            Console.WriteLine("4 - Buscar por modelo (busca sequencial)");
            Console.WriteLine("5 - Buscar por ID (busca binária)");
            Console.WriteLine("6 - Selecionar carro disponível mais barato");
            Console.WriteLine("7 - Selecionar carro disponível mais caro");
            Console.WriteLine("8 - Alugar carro");
            Console.WriteLine("9 - Devolver carro");
            Console.WriteLine("0 - Sair");
        }

        static void ListarCarros(List<Carro> lista)
        {
            Console.WriteLine();
            Console.WriteLine("{0,-4}{1,-12}{2,-10}{3,-6}{4,-12}{5}", "ID", "Marca", "Modelo", "Ano", "Diária", "Situação");
            foreach (Carro c in lista)
            {
                MostrarLinha(c);
            }
        }

        static void MostrarLinha(Carro c)
        {
            string situacao = c.Disponivel ? "Disponível" : "Alugado para " + c.Cliente;
            Console.WriteLine("{0,-4}{1,-12}{2,-10}{3,-6}{4,-12}{5}", c.Id, c.Marca, c.Modelo, c.Ano, "R$ " + c.Diaria.ToString("F2"), situacao);
        }


        static void OrdenarPorDiaria()
        {
            List<Carro> copia = new List<Carro>(frota);
            BubbleSort(copia);
            Console.WriteLine();
            Console.WriteLine("Carros ordenados por diária (Bubble Sort):");
            ListarCarros(copia);
        }

        static void OrdenarPorAno()
        {
            List<Carro> copia = new List<Carro>(frota);
            InsertionSort(copia);
            Console.WriteLine();
            Console.WriteLine("Carros ordenados por ano (Insertion Sort):");
            ListarCarros(copia);
        }

        static void BubbleSort(List<Carro> lista)
        {
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 0; j < lista.Count - 1 - i; j++)
                {
                    if (lista[j].Diaria > lista[j + 1].Diaria)
                    {
                        Carro aux = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = aux;
                    }
                }
            }
        }

        static void InsertionSort(List<Carro> lista)
        {
            for (int i = 1; i < lista.Count; i++)
            {
                Carro atual = lista[i];
                int j = i - 1;
                while (j >= 0 && lista[j].Ano > atual.Ano)
                {
                    lista[j + 1] = lista[j];
                    j--;
                }
                lista[j + 1] = atual;
            }
        }


        static void BuscarPorModelo()
        {
            Console.Write("Digite o modelo: ");
            string texto = LerTexto().Trim();
            if (texto.Length == 0)
            {
                Console.WriteLine("Digite um modelo válido.");
                return;
            }

            bool achou = false;

            for (int i = 0; i < frota.Count; i++)
            {
                if (frota[i].Modelo.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (!achou)
                    {
                        Console.WriteLine();
                        Console.WriteLine("{0,-4}{1,-12}{2,-10}{3,-6}{4,-12}{5}", "ID", "Marca", "Modelo", "Ano", "Diária", "Situação");
                    }
                    MostrarLinha(frota[i]);
                    achou = true;
                }
            }

            if (!achou) Console.WriteLine("Nenhum carro encontrado.");
        }

        static void BuscarPorId()
        {
            int id = LerInteiro("Digite o ID: ");
            int posicao = BuscaBinaria(id);

            if (posicao == -1)
            {
                Console.WriteLine("Carro não encontrado.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("{0,-4}{1,-12}{2,-10}{3,-6}{4,-12}{5}", "ID", "Marca", "Modelo", "Ano", "Diária", "Situação");
                MostrarLinha(frota[posicao]);
            }
        }

        static int BuscaBinaria(int id)
        {
            int inicio = 0;
            int fim = frota.Count - 1;

            while (inicio <= fim)
            {
                int meio = (inicio + fim) / 2;

                if (frota[meio].Id == id) return meio;
                else if (frota[meio].Id < id) inicio = meio + 1;
                else fim = meio - 1;
            }

            return -1;
        }


        static void MostrarMaisBarato()
        {
            Carro c = SelecionarMaisBarato();
            Console.WriteLine();
            if (c == null) Console.WriteLine("Não há carros disponíveis.");
            else
            {
                Console.WriteLine("Carro disponível mais barato:");
                MostrarLinha(c);
            }
        }

        static void MostrarMaisCaro()
        {
            Carro c = SelecionarMaisCaro();
            Console.WriteLine();
            if (c == null) Console.WriteLine("Não há carros disponíveis.");
            else
            {
                Console.WriteLine("Carro disponível mais caro:");
                MostrarLinha(c);
            }
        }

        static Carro SelecionarMaisBarato()
        {
            Carro escolhido = null;
            for (int i = 0; i < frota.Count; i++)
            {
                if (!frota[i].Disponivel) continue;
                if (escolhido == null || frota[i].Diaria < escolhido.Diaria)
                    escolhido = frota[i];
            }
            return escolhido;
        }

        static Carro SelecionarMaisCaro()
        {
            Carro escolhido = null;
            for (int i = 0; i < frota.Count; i++)
            {
                if (!frota[i].Disponivel) continue;
                if (escolhido == null || frota[i].Diaria > escolhido.Diaria)
                    escolhido = frota[i];
            }
            return escolhido;
        }


        static void AlugarCarro()
        {
            int id = LerInteiro("ID do carro: ");
            int posicao = BuscaBinaria(id);

            if (posicao == -1)
            {
                Console.WriteLine("Carro não encontrado.");
                return;
            }

            Carro c = frota[posicao];
            if (!c.Disponivel)
            {
                Console.WriteLine("Esse carro já está alugado.");
                return;
            }

            Console.Write("Nome do cliente: ");
            string cliente = LerTexto();
            int dias = LerInteiro("Quantidade de dias: ");

            if (cliente.Trim() == "" || dias < 1)
            {
                Console.WriteLine("Dados inválidos.");
                return;
            }

            c.Disponivel = false;
            c.Cliente = cliente.Trim();
            double total = c.Diaria * dias;
            Console.WriteLine("{0} {1} alugado para {2}. Total: R$ {3}", c.Marca, c.Modelo, c.Cliente, total.ToString("F2"));
        }

        static void DevolverCarro()
        {
            int id = LerInteiro("ID do carro: ");
            int posicao = BuscaBinaria(id);

            if (posicao == -1)
            {
                Console.WriteLine("Carro não encontrado.");
                return;
            }

            Carro c = frota[posicao];
            if (c.Disponivel)
            {
                Console.WriteLine("Esse carro não está alugado.");
                return;
            }

            c.Disponivel = true;
            c.Cliente = "";
            Console.WriteLine("{0} {1} devolvido.", c.Marca, c.Modelo);
        }


        static string LerTexto()
        {
            string texto = Console.ReadLine();
            if (texto == null) Environment.Exit(0);
            return texto;
        }

        static int LerInteiro(string mensagem)
        {
            int valor;
            Console.Write(mensagem);
            while (!int.TryParse(LerTexto(), out valor))
            {
                Console.Write("Número inválido. " + mensagem);
            }
            return valor;
        }
    }
}
