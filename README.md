# JT Books

Projeto de API para gerenciar livros, autores e pagamentos.

## Índice

- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
- [Executando o Projeto](#executando-o-projeto)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Contato](#contato)

## Pré-requisitos

Antes de começar, certifique-se de ter os seguintes requisitos instalados:

- [SDK do .NET Core 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

## Instalação

1. Clone o repositório:
    ```bash
    git clone https://github.com/dennyphilipp/jt-books-api.git
    ```
2. Navegue até o diretório do projeto:
    ```bash
    cd jt-books-api
    ```
3. Instale as dependências do projeto (restaurando pacotes NuGet):
    ```bash
    dotnet restore
    ```


## Configuração do Banco de Dados

1. Crie um banco de dados PostgreSQL:
    ```sql
    CREATE DATABASE db_jt;
    ```

2. Atualize a string de conexão no arquivo `appsettings.json` com as informações do seu banco de dados:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=db_jt;Username=postgres;Password=root"
    }
    ```

3. As migrations e scripts de criação de tabela são feitos na subida da API.

## Executando o Projeto

1. Execute a aplicação:
    ```bash
    dotnet run
    ```
2. A API estará disponível em:
    ```
    http://localhost:5077/swagger/index.html
    ```

3. Execute os testes:
    ```bash
    dotnet test
    ```
## Tecnologias Utilizadas

- [.NET Core 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [PostgreSQL](https://www.postgresql.org/)
- [Swagger](https://swagger.io/)
