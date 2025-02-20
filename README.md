# Simulação de Empréstimo - Desafio Inbursa

Este é um projeto de simulação de empréstimo desenvolvido como parte de um desafio técnico para a Inbursa. A aplicação oferece uma simulação de empréstimo, permitindo calcular o valor das parcelas, os juros totais e o saldo devedor a cada mês, com base nas informações fornecidas pelo usuário.

## Tecnologias Utilizadas

- **.NET 8**: Framework para desenvolvimento da aplicação.
- **C#**: Linguagem de programação principal.
- **Entity Framework Core**: ORM para comunicação com o banco de dados usando o padrão Code First.
- **Migrations**: Para gerenciamento de versões do banco de dados.
- **AutoMapper**: Para mapeamento de objetos entre camadas.
- **Swagger**: Para documentação da API e facilitar os testes via interface web.
- **DDD (Domain-Driven Design)**: Estrutura de design de software usada para estruturar o código de forma limpa e eficiente.

## Funcionalidades

- Simulação de empréstimos com cálculos das parcelas, juros e saldo devedor.
- Geração de cronograma de pagamentos detalhado, com principal, juros e saldo devedor para cada mês.
- Armazenamento de dados de empréstimos e cronograma de pagamentos no banco de dados.
- API RESTful para interação com o sistema.

## Como Rodar o Projeto

### Pré-requisitos

- **.NET 8 SDK**: Certifique-se de ter o SDK do .NET 8 instalado na sua máquina.
- **SQL Server ou Banco de Dados de sua Escolha**: Configure uma instância de banco de dados, se não estiver utilizando o SQL Server.
- **Visual Studio ou VS Code**: IDE para rodar o projeto.

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/davidgomesdh/DesafioInbursa.git
   cd DesafioInbursa

2. Restaure as dependências do projeto:
   ```bash
   dotnet restore

3. Execute as migrations para criar o banco de dados:
   ```bash
   dotnet ef database update

4. Execute a aplicação:
   ```bash
   dotnet run

5. Acesso a API via Swagger ou Postman
  - Navegue para http://localhost:12558/swagger/index.html para interagir com a documentação da API e testar os endpoints.

## Endpoints Disponíveis
  - POST /api/loan/simulate: Realiza a simulação de um empréstimo. Recebe um objeto LoanViewModel e retorna o cronograma de pagamentos, valor das parcelas e juros totais.

## Exemplo de Requisição
*Corpo da Requisição*
```json
  {
  "loanAmount": 10000,
  "annualInterestRate": 0.12,
  "numberOfMonths": 24
}
```

*Resposta*
```json
{
  "monthlyPayment": 506.56,
  "totalInterest": 1215.57,
  "totalPayment": 11215.57,
  "paymentSchedule": [
    {
      "month": 1,
      "principal": 472.72,
      "interest": 83.33,
      "balance": 9527.28
    },
    ...
  ]
}
```
