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
- **BCrypt.Net**: Para criptografia segura de senhas.
- **JWT (Bearer Token)**: Para autenticação e autorização via token.

## Funcionalidades

- **Cadastro de despesas**: Permite o registro de novas despesas com informações como título, descrição, valor, data e tipo de pagamento.
- **Consulta de despesas**: Permite consultar despesas existentes por ID ou listar todas as despesas cadastradas.
- **Atualização de despesas**: Oferece a possibilidade de editar uma despesa já registrada.
- **Remoção de despesas**: Permite a exclusão de despesas, facilitando o controle do fluxo financeiro.
- **Validação de dados**: Utilização do **FluentValidation** para garantir que os dados inseridos sejam válidos antes de serem persistidos.
- **Documentação de API**: A API conta com documentação nos retornos e erros esperados nos endpoints, facilitando a exploração.

### 🔐 Funcionalidades de Usuário

- **Cadastro de usuários**
- **Login com geração de JWT**
- **Proteção de rotas (Expenses) utilizando Bearer Token**
- **Criptografia de senha com BCrypt**
- **Testes de unidade para os casos de uso de usuários**

## Arquitetura

A arquitetura do projeto foi estruturada utilizando os princípios da **Clean Architecture** e **DDD**, o que permite maior organização e clareza no código, além de facilitar a escalabilidade e manutenção futura.

### Camadas da Aplicação

1. **Domain**: Contém as entidades e interfaces essenciais para o funcionamento do sistema.
   - Exemplo: `IExpenseWriteRepository`, `IExpenseReadRepository`, `IUserRepository`, `IUnitOfWork`...
   
2. **Application**: Contém a lógica de negócios, com casos de uso, regras de aplicação e validações.
   - Exemplo: `ExpensesUseCases`, `UserUseCases`, `ExpenseValidator`, `UserValidator`...

3. **Infrastructure**: Responsável pela implementação dos repositórios e interação com o banco de dados.
   - Exemplo: `ExpenseRepository`, `UserRepository`, `UnitOfWork`...

4. **WebAPI**: Camada responsável por expor a API RESTful, utilizando controllers que representam os casos de uso.
   - Exemplo: `ExpenseController`, `UserController`, `LoginController`.

5. **Exception**: Responsável pelas exceções personalizadas, gerando respostas mais amigáveis a usuários.
   - Exemplo: `ErrorOnValidationException`, `NotFoundException`...

6. **Communication**: Contém as requisições e respostas esperadas na entrada e saída de dados, mantendo a segurança de dados sensíveis.
   - Exemplo: `RegisterExpenseRequest`, `RegisterExpenseResponse`, `LoginRequest`, `RegisterUserRequest`...

7. **Tests**: Contém os testes unitários das validações e regras de negócio, assegurando a qualidade e o correto funcionamento de cada componente.

## Endpoints da API

### Despesas

- **POST /api/expenses**: Cria uma nova despesa.
  - Exige autenticação Bearer Token.
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
  - Exige autenticação Bearer Token.

- **GET /api/expenses/{id}**: Retorna uma despesa específica pelo ID.
  - Exige autenticação Bearer Token.

- **PUT /api/expenses/{id}**: Atualiza uma despesa existente.
  - Exige autenticação Bearer Token.

- **DELETE /api/expenses/{id}**: Exclui uma despesa.
  - Exige autenticação Bearer Token.

### Usuários

- **POST /api/users**: Cadastra um novo usuário.
  - Exemplo de corpo:
    ```json
    {
      "name": "Ramon Rocha",
      "email": "ramon@gmail.com",
      "password": "!Password123"
    }
    ```

- **POST /api/login**: Realiza login e retorna o token JWT.
  - Exemplo de corpo:
    ```json
    {
      "email": "ramon@gmail.com",
      "password": "!Password123"
    }
    ```

  - Exemplo de resposta:
    ```json
    {
      "name": "Ramon Rocha",
      "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
    }
    ```

## Abordagem de Desenvolvimento

### Boas Práticas

- **Clean Architecture e DDD**: O projeto foi estruturado para seguir os princípios da **Clean Architecture** e **Domain-Driven Design (DDD)**, separando responsabilidades e facilitando a escalabilidade.

- **Princípios SOLID**: O projeto segue os princípios **SOLID** para garantir um código mais coeso, desacoplado e fácil de manter.

- **Swagger**: Utilização do **Swagger** para fornecer documentação interativa da API, facilitando o desenvolvimento e testes.

- **Testes automatizados**: Implementação de **testes unitários** com **XUnit**, **Bogus** e **FluentAssertions**, garantindo a qualidade do código e o comportamento esperado das validações e regras de negócio.

## 🚀 Features Futuras

- **Gestão de Usuários Avançada**: Controle de permissões e roles para acesso a determinados endpoints.
- **Mocks**: Implementação de testes com objetos simulados (mocks) para isolar dependências externas e testar comportamentos específicos.
- **Testes de Integração**: Escrita de testes que validam o funcionamento completo entre as camadas da aplicação, incluindo banco de dados e endpoints.
- **Deploy**: Aprendizado e aplicação de técnicas para publicação da API em ambientes externos (nuvem ou servidores locais).
- **Pipelines**: Configuração de pipelines de CI/CD para automatizar testes, builds e deploys sempre que houver alterações no código.
