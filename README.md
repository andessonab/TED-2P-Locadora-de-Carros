# Locadora de Carros — TED de Estruturas de Dados

**Curso:** Sistemas de Informação — 2º período  
**Instituição:** UNISAPIENS  
**Professora:** Rosângela  
**Grupo:** 5

**Integrantes:**
- Carlos Henrique Farias dos Santos
- Andesson Albano
- Elias de Souza

## Sobre o projeto

Neste trabalho, desenvolvemos um programa em C# para simular algumas atividades de uma locadora de carros. A ideia foi colocar em prática os conteúdos de estruturas de dados e algoritmos estudados em sala.

O sistema funciona pelo console e começa com oito veículos cadastrados. É possível consultar os carros, pesquisar por modelo ou ID, organizar a lista por diferentes critérios e simular um aluguel ou uma devolução.

## Estrutura utilizada

Os carros são armazenados em uma `List<Carro>`, que é uma estrutura de dados linear. Cada carro tem ID, marca, modelo, ano, valor da diária, situação de disponibilidade e, quando está alugado, o nome do cliente.

Escolhemos essa estrutura porque ela permite percorrer os veículos por posição e aplicar os algoritmos trabalhados na disciplina.

## Algoritmos do sistema

**Ordenação**

- **Bubble Sort:** organiza os carros do menor para o maior valor da diária. O algoritmo compara veículos vizinhos e troca suas posições quando necessário.
- **Insertion Sort:** organiza os carros pelo ano, do mais antigo para o mais recente, inserindo cada veículo na posição correta.

Nas duas opções, usamos uma cópia da lista. Assim, os carros continuam organizados por ID na lista original, o que é importante para a busca binária.

**Busca**

- **Busca sequencial:** percorre a lista até encontrar os carros cujo modelo corresponde ao texto digitado. Por exemplo, é possível pesquisar por `HB20`.
- **Busca binária:** localiza um veículo pelo ID. Ela aproveita o fato de que a lista original está em ordem crescente de ID para reduzir a quantidade de comparações.

**Seleção**

- **Menor diária:** percorre os carros disponíveis e escolhe aquele com o preço mais baixo.
- **Maior diária:** faz a mesma verificação, mas escolhe o carro disponível com o preço mais alto.

## Opções do menu

| Opção | O que faz |
|---|---|
| 1 | Lista os carros cadastrados |
| 2 | Ordena por diária com Bubble Sort |
| 3 | Ordena por ano com Insertion Sort |
| 4 | Busca carros pelo modelo |
| 5 | Busca um carro pelo ID |
| 6 | Mostra o carro disponível mais barato |
| 7 | Mostra o carro disponível mais caro |
| 8 | Aluga um carro |
| 9 | Devolve um carro |
| 0 | Encerra o programa |

Para alugar um veículo, o usuário informa o ID, o nome do cliente e a quantidade de dias. O programa verifica se o carro está disponível e calcula o total multiplicando a diária pelos dias. Depois disso, o veículo fica marcado como alugado. Na devolução, ele volta a ficar disponível.

## Como executar

É necessário ter o **.NET SDK 8** instalado no computador.

Abra um terminal na pasta do projeto e digite:

```bash
dotnet run --project LocadoraCarros.csproj
```

O menu será exibido e você poderá escolher as opções digitando seus números.

**Exemplo para conferir o funcionamento:**

1. Digite `1` para listar os oito veículos.
2. Digite `2` para visualizar a ordenação por diária e `3` para a ordenação por ano.
3. Na opção `4`, pesquise por `HB20`. Na opção `5`, procure o ID `4`.
4. Na opção `8`, escolha o ID `5` (Toyota Corolla), informe um nome e `15` dias. Com a diária de R$ 189,90, o total calculado será R$ 2.848,50.
5. Tente alugar o mesmo carro novamente para conferir a mensagem de indisponibilidade. Depois, use a opção `9` para devolvê-lo.

## Testes e arquivos

O projeto foi compilado com **.NET 8** no GitHub Actions. Também foram executados **18 testes automáticos**, que verificam as principais opções do menu, incluindo buscas, ordenações, seleção, aluguel, devolução e tratamento de entradas inválidas.

O código e os testes podem ser consultados nestes arquivos:

- `Program.cs` — classes, algoritmos e funcionamento do menu.
- `LocadoraCarros.csproj` — configuração do projeto C#.
- `tests/test_console.py` — testes automáticos de execução.
- `docs/ROTEIRO_DE_TESTES.md` — situações que podem ser testadas manualmente.
- `.github/workflows/build.yml` — configuração da compilação e dos testes no GitHub.

Os resultados da compilação e dos testes ficam disponíveis na aba **Ações** do repositório.

## Considerações finais

Com o desenvolvimento do sistema, conseguimos observar a diferença entre ordenar, buscar e selecionar informações dentro de uma mesma lista. Também vimos por que a organização dos dados faz diferença: a busca binária, por exemplo, depende de os IDs estarem em ordem.

O programa é uma simulação para a disciplina. Os dados ficam na memória enquanto ele está aberto, portanto os aluguéis não são salvos quando o sistema é fechado. Um próximo passo seria acrescentar cadastro de novos carros e armazenamento dos dados em arquivo.

**O relatório completo em PDF, com as explicações e as capturas de tela, será entregue separadamente na plataforma da disciplina.**
