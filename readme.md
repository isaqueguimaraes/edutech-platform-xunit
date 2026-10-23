# 🎓 EduTechPlatform

Plataforma de console em **C# / .NET 10** que implementa as regras de negócio acadêmicas e financeiras de uma instituição de ensino fictícia, acompanhada de suítes de **testes unitários parametrizados com xUnit**.

Projeto desenvolvido para a disciplina **Garantia da Qualidade de Software** (Gestão e Qualidade de Software, Ânima Educação), com foco em boas práticas de testes automatizados, versionamento e documentação.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![xUnit](https://img.shields.io/badge/tests-xUnit-5E2D91)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📑 Sumário

- [Visão geral](#-visão-geral)
- [Requisitos do ambiente de execução](#-requisitos-do-ambiente-de-execução)
- [Estrutura do projeto](#-estrutura-do-projeto)
- [Classes de serviço](#-classes-de-serviço)
- [Guia de execução via CLI](#-guia-de-execução-via-cli)
- [Cobertura dos testes parametrizados](#-cobertura-dos-testes-parametrizados)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Contribuidores](#-contribuidores)
- [Licença](#-licença)

---

## 📖 Visão geral

A **EduTechPlatform** simula o núcleo de regras de negócio de uma plataforma educacional. A lógica está distribuída em três domínios acadêmicos/financeiros, cada um implementado em uma classe de serviço no projeto `EduTechPlatform.App`:

| Domínio | Classe | Responsabilidade |
|---------|--------|------------------|
| Desempenho acadêmico | `NotaDesempenhoService` | Cálculo da média ponderada e definição da situação acadêmica do aluno. |
| Assiduidade | `FrequenciaService` | Cálculo do percentual de presença e aprovação por frequência. |
| Financeiro e matrícula | `MatriculaFinanceiraService` | Cálculo da mensalidade com descontos e elegibilidade para rematrícula. |

A qualidade das regras é garantida por testes unitários automatizados com **xUnit**, utilizando `[Theory]` e `[InlineData]` para validar múltiplos cenários com um único método de teste.

---

## 🛠 Requisitos do ambiente de execução

- **[.NET SDK 10.0](https://dotnet.microsoft.com/download)** (ou superior)
- **[Git](https://git-scm.com/downloads)**
- Terminal (PowerShell, CMD, Bash, Zsh etc.)
- IDE opcional: Visual Studio 2022+, VS Code (com extensão C# Dev Kit) ou JetBrains Rider

Para verificar a versão do .NET instalada:

```bash
dotnet --version
```

---

## 📂 Estrutura do projeto

```text
edutech-platform-xunit/
├── EduTechPlatform.sln
├── EduTechPlatform.App/
│   ├── EduTechPlatform.App.csproj
│   ├── Program.cs
│   ├── NotaDesempenhoService.cs
│   ├── FrequenciaService.cs
│   └── MatriculaFinanceiraService.cs
├── EduTechPlatform.Tests/
│   ├── EduTechPlatform.Tests.csproj
│   ├── NotaDesempenhoServiceTests.cs
│   ├── FrequenciaServiceTests.cs
│   └── MatriculaFinanceiraServiceTests.cs
├── .gitignore
├── LICENSE
└── README.md
```

- **`EduTechPlatform.App`**: projeto de console (`net10.0`) com as regras de negócio.
- **`EduTechPlatform.Tests`**: projeto de testes xUnit (`net10.0`) que referencia o projeto `EduTechPlatform.App`.

---

## 💼 Classes de serviço

### 1. `NotaDesempenhoService`

Responsável pelo desempenho acadêmico do aluno.

#### `CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)`

Calcula a média final com os seguintes pesos:

| Avaliação | Peso |
|-----------|:----:|
| Nota 1 | 3 |
| Nota 2 | 3 |
| Nota do Projeto | 4 |

Fórmula: `((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10`

#### `ObterSituacaoAcademica(decimal mediaFinal)`

| Média final | Situação |
|:-----------:|:--------:|
| Maior ou igual a 7.0 | `APROVADO` |
| Entre 5.0 e 6.99 | `RECUPERACAO` |
| Menor que 5.0 | `REPROVADO` |

### 2. `FrequenciaService`

Responsável pelo controle de assiduidade do aluno.

#### `CalcularPorcentagemPresenca(int aulasTotais, int faltas)`

Retorna o percentual de presença: `((aulasTotais - faltas) / (double)aulasTotais) * 100`

#### `AprovadoPorFrequencia(int aulasTotais, int faltas)`

Retorna `true` se o aluno tiver **no mínimo 75%** de presença. Caso contrário, retorna `false`.

### 3. `MatriculaFinanceiraService`

Responsável pelas regras financeiras e de rematrícula.

#### `CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)`

| Condição | Desconto | Cálculo |
|----------|:--------:|---------|
| Aluno bolsista (independente do dia de pagamento) | 50% | `valorBase * 0.50m` |
| Não bolsista, pagamento **até o dia 5** | 10% (pontualidade) | `valorBase * 0.90m` |
| Não bolsista, pagamento **após o dia 5** | Nenhum | `valorBase` (valor integral) |

#### `PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)`

Retorna `true` **apenas** se `possuiPendenciaFinanceira == false` **E** a `situacaoAcademica` **NÃO** for `"REPROVADO"`.

---

## 🚀 Guia de execução via CLI

### 1. Clonar o repositório

```bash
git clone https://github.com/isaqueguimaraes/edutech-platform-xunit.git
```

### 2. Acessar a pasta do projeto

```bash
cd edutech-platform-xunit
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Compilar a solução

```bash
dotnet build
```

Se tudo estiver correto, a saída final indicará **Build succeeded** (compilação bem-sucedida), com 0 erros.

### 5. Executar os testes unitários

Na raiz do repositório (onde está o arquivo `EduTechPlatform.sln`), execute:

```bash
dotnet test
```

Para uma saída mais detalhada, com o nome de cada cenário executado:

```bash
dotnet test --logger "console;verbosity=detailed"
```

Para executar apenas o projeto de testes:

```bash
dotnet test EduTechPlatform.Tests/EduTechPlatform.Tests.csproj
```

Ao final da execução, todos os cenários das **três suítes de teste** devem ser aprovados, com uma saída semelhante a:

```text
Aprovado!  – Com falha: 0, Aprovado: 15, Ignorado: 0, Total: 15
```

---

## 🧪 Cobertura dos testes parametrizados

Os testes utilizam os atributos do xUnit:

- **`[Theory]`**: marca um método de teste que roda várias vezes, uma para cada conjunto de dados.
- **`[InlineData(...)]`**: define cada conjunto de parâmetros de entrada e o resultado esperado, evitando a duplicação de métodos de teste.

São **6 métodos de teste** distribuídos em **3 classes**, que cobrem **15 cenários** e todos os métodos das três classes de serviço.

### `NotaDesempenhoServiceTests`

#### Teste 1: Média ponderada (`CalcularMediaPonderada`)

| Nota 1 | Nota 2 | Nota Projeto | Resultado esperado | Cenário |
|:------:|:------:|:------------:|:------------------:|---------|
| 7.0 | 7.0 | 7.0 | 7.0 | Notas iguais |
| 10.0 | 10.0 | 5.0 | 8.0 | (30 + 30 + 20) / 10 |

#### Teste 2: Situação acadêmica (`ObterSituacaoAcademica`)

| Média final | Resultado esperado |
|:-----------:|:------------------:|
| 8.5 | `APROVADO` |
| 6.0 | `RECUPERACAO` |
| 4.2 | `REPROVADO` |

### `FrequenciaServiceTests`

#### Teste 1: Percentual de presença (`CalcularPorcentagemPresenca`)

| Aulas totais | Faltas | Resultado esperado | Cenário |
|:------------:|:------:|:------------------:|---------|
| 80 | 20 | 75.0 | 60 presenças em 80 aulas |
| 100 | 10 | 90.0 | 90 presenças em 100 aulas |

#### Teste 2: Aprovação por frequência (`AprovadoPorFrequencia`)

| Aulas totais | Faltas | Resultado esperado | Cenário |
|:------------:|:------:|:------------------:|---------|
| 80 | 20 | `true` | 75% de presença → aprovado |
| 80 | 21 | `false` | Abaixo de 75% → reprovado por falta |

### `MatriculaFinanceiraServiceTests`

#### Teste 1: Cálculo da mensalidade (`CalcularValorMensalidade`)

| Valor base | Dia de pagamento | Bolsista | Resultado esperado | Cenário |
|:----------:|:----------------:|:--------:|:------------------:|---------|
| 1000.00 | 10 | `true` | 500.00 | Bolsista → 50% de desconto |
| 1000.00 | 4 | `false` | 900.00 | Não bolsista, paga no dia 4 → 10% de desconto |
| 1000.00 | 10 | `false` | 1000.00 | Não bolsista, paga no dia 10 → sem desconto |

#### Teste 2: Elegibilidade para rematrícula (`PodeRealizarRematricula`)

| Pendência financeira | Situação acadêmica | Resultado esperado | Cenário |
|:--------------------:|:------------------:|:------------------:|---------|
| `false` | `APROVADO` | `true` | Sem pendência + aprovado → permite |
| `true` | `APROVADO` | `false` | Com pendência + aprovado → bloqueia |
| `false` | `REPROVADO` | `false` | Sem pendência + reprovado → bloqueia |

---

## 🧰 Tecnologias utilizadas

- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [.NET 10](https://dotnet.microsoft.com/)
- [xUnit](https://xunit.net/)
- [Git](https://git-scm.com/) e [GitHub](https://github.com/)

---

## 📄 Licença

Este projeto está licenciado sob a **Licença MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.
