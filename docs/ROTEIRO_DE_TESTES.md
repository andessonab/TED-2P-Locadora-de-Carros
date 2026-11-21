# Roteiro de verificação - Locadora de Carros

Estes casos permitem reproduzir e confirmar as funcionalidades. As capturas de tela do relatório original mostram os exemplos indicados; **o roteiro não substitui executar o programa na máquina da equipe**.

| ID | Ação | Entrada | Resultado esperado |
|---|---|---|---|
| T01 | Listagem | Menu `1` | Apresenta os 8 carros e respectivos IDs, anos, diárias e estado |
| T02 | Bubble Sort | Menu `2` | Diárias do menor para o maior valor: `89,90` ... `329,00` |
| T03 | Insertion Sort | Menu `3` | Anos crescentes: 2021, 2022, 2022, 2023, 2023, 2024, 2024, 2024 |
| T04 | Busca sequencial | Menu `4`, modelo `HB20` | Mostra o carro Hyundai HB20, ID `3` |
| T05 | Busca sequencial com minúsculas | Menu `4`, `hb20` | Encontra o mesmo carro |
| T06 | Busca binária, existente | Menu `5`, ID `4` | Mostra Volkswagen Polo |
| T07 | Busca binária, inexistente | Menu `5`, ID `12` | Exibe `Carro não encontrado.` |
| T08 | Seleção menor valor | Menu `6` antes de alugar | Apresenta Fiat Mobi por R$ 89,90 |
| T09 | Seleção maior valor | Menu `7` antes de alugar | Apresenta Toyota Hilux por R$ 329,00 |
| T10 | Aluguel | Menu `8`, ID `5`, nome e `15` dias | Corolla alugado; total de R$ 2.848,50 |
| T11 | Repetição do aluguel | Menu `8`, ID `5` novamente | Exibe `Esse carro já está alugado.` |
| T12 | Devolução | Menu `9`, ID `5` | Informa que Toyota Corolla foi devolvido |
| T13 | Quantidade de dias inválida | Menu `8`, ID `5`, nome, `0` dias | Exibe `Dados inválidos.` e mantém o carro disponível |
| T14 | Nome do cliente em branco | Menu `8`, ID `5`, apenas espaços, `2` dias | Exibe `Dados inválidos.` |
| T15 | Busca de modelo vazia | Menu `4`, Enter | Exibe `Digite um modelo válido.` |
| T16 | Opção desconhecida | Menu `99` | Exibe `Opção inválida.` |
| T17 | Verificação da lista após ordenar | Menu `2`, depois `3`, depois `1` | A listagem original continua por ID crescente |
| T18 | Encerramento | Menu `0` | Exibe `Programa encerrado.` |

**Importante:** reinicie o programa para voltar à frota inicial antes de testar cenários que dependem da disponibilidade dos carros. O programa não persiste alterações após o encerramento.

## Conferência para entregar

- [ ] `dotnet build` executa sem erros na máquina da equipe.
- [ ] `dotnet run` abre o menu.
- [ ] Testes T01 a T18 conferidos e anotados pela equipe.
- [ ] Relatório e capturas correspondem ao código final.
- [ ] Todas as pessoas do Grupo 5 estão nomeadas no README e na capa.
- [ ] Repositório do GitHub está **público**.
- [ ] Link copiado e enviado pela pessoa designada antes do prazo.
