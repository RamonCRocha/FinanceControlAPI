# Finance Control API

**Finance Control API** é uma API RESTful desenvolvida com o intuito de gerenciar despesas e controlar o fluxo financeiro de forma simples e eficiente. O projeto utiliza **Clean Architecture**, **DDD (Domain-Driven Design)**, **FluentValidation**, **Swagger**, **Princípios SOLID**, entre outras tecnologias, garantindo alta manutenibilidade e escalabilidade.

## Tecnologias Utilizadas

- **.NET 8**: Plataforma de desenvolvimento para construir a API.
- **FluentValidation**: Para validação de dados de entrada.
- **Swagger**: Documentação da API para facilitar os testes e entendimento dos endpoints.
- **AutoMapper**: Para realizar o mapeamento entre objetos de diferentes camadas.
- **XUnit**: Framework para testes unitários.
- **FluentAssertions**: Para melhorar a legibilidade e assertividade dos testes.
- **Bogus**: Biblioteca para gerar dados falsos para testes automatizados.
- **EntityFramework**: Para mapeamento com o banco de dados.
- **SQLServer**: Banco de dados utilizado.

## Funcionalidades

- **Cadastro de despesas**: Permite o registro de novas despesas com informações como título, descrição, valor, data e tipo de pagamento.
- **Consulta de despesas**: Permite consultar despesas existentes por ID ou listar todas as despesas cadastradas.
- **Atualização de despesas**: Oferece a possibilidade de editar uma despesa já registrada.
- **Remoção de despesas**: Permite a exclusão de despesas, facilitando o controle do fluxo financeiro.
- **Validação de dados**: Utilização do **FluentValidation** para garantir que os dados inseridos sejam válidos antes de serem persistidos.
- **Documentação de API**: A API conta com documentação nos retornos e erros esperados nos endpoints, facilitando a exploração.

## Arquitetura

A arquitetura do projeto foi estruturada utilizando os princípios da **Clean Architecture** e **DDD**, o que permite maior organização e clareza no código, além de facilitar a escalabilidade e manutenção futura.

### Camadas da Aplicação

1. **Domain**: Contém as entidades e interfaces essenciais para o funcionamento do sistema.
   - Exemplo: `IExpenseWriteRepository`, `IExpenseReadRepository`, `IUnitOfWork`...
   
2. **Application**: Contém a lógica de negócios, com casos de uso, regras de aplicação e validações.
   - Exemplo: `ExpensesUseCases`, `ExpenseValidator`...

3. **Infrastructure**: Responsável pela implementação dos repositórios e interação com o banco de dados.
   - Exemplo: `ExpenseRepository`, `UnitOfWork`...

4. **WebAPI**: Camada responsável por expor a API RESTful, utilizando controllers que representam os casos de uso.
   - Exemplo: `ExpenseController`.

5. **Exception**: Responsável pelas exceções personalizadas, gerando respostas mais amigaveis a usuários.
   - Exemplo: `ErrorOnValidationException`, `NotFoundException`...

6. **Communication**: Contém as requisições e respostas experadas na entrada e saída de dados, mantendo a segurança à dados sensíveis.
   - Exemplo: `RegisterExpenseRequest`, `RegisterExpenseResponse`...

8. **Tests**: Contém os testes unitários das validações esperadas, assegurando a qualidade e o correto funcionamento de cada componente.

## Endpoints da API

### Despesas

- **POST /api/expenses**: Cria uma nova despesa.
  - Exemplo de corpo:
    ```json
    {
    "title": "Mercado",
    "description": "Compras da primeira semana",
    "date": "2025-04-03T22:04:18.918Z",
    "amount": 120.50,
    "paymentType": 1
    }
    ```

- **GET /api/expenses**: Retorna todas as despesas.

- **GET /api/expenses/{id}**: Retorna uma despesa específica pelo ID.

- **PUT /api/expenses/{id}**: Atualiza uma despesa existente.

- **DELETE /api/expenses/{id}**: Exclui uma despesa.


## Abordagem de Desenvolvimento

### Boas Práticas

- **Clean Architecture e DDD**: O projeto foi estruturado para seguir os princípios da **Clean Architecture** e **Domain-Driven Design (DDD)**, separando responsabilidades e facilitando a escalabilidade.

- **Princípios SOLID**: O projeto segue os princípios **SOLID** para garantir um código mais coeso, desacoplado e fácil de manter..

- **Swagger**: Utilização do **Swagger** para fornecer documentação interativa da API, facilitando o desenvolvimento e testes.

- **Testes automatizados**: Implementação de **testes unitários** com **XUnit** e **FluentAssertions**, garantindo a qualidade do código e o comportamento esperado das validações de entrada de dados.


## 🚀 Features Futuras

- **Gestão de Usuários**: Implementação de autenticação e autorização, permitindo o gerenciamento de usuários e controle de acessos através de roles e permissões.
- **TDD (Test-Driven Development)**: Adoção do desenvolvimento orientado a testes, onde os testes serão escritos antes do código, para garantir uma maior confiabilidade e cobertura de testes.
- **Autenticação JWT**: Implementação de **JSON Web Tokens (JWT)** para autenticação de usuários de forma segura e eficiente, possibilitando a criação de um sistema de login e proteção de rotas da API.

