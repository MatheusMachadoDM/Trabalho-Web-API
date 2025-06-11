# Sistema de Gerenciamento de Reservas

[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![Backend](https://img.shields.io/badge/Backend-C%23%20.NET-blue)
![Frontend](https://img.shields.io/badge/Frontend-React%20TypeScript-brightgreen)

Este projeto consiste em um sistema completo para o gerenciamento de reservas de um hotel. Ele é composto por um backend construído em **C\# (.NET)** e um frontend desenvolvido com **React e TypeScript**.

## Visão Geral

O sistema Hotel permite:

* **Gerenciamento de Reservas:** Criar, visualizar, atualizar e cancelar reservas.
* **Integração Full-Stack:** Comunicação eficiente entre o frontend e o backend através de uma API RESTful.

## Tecnologias Utilizadas

### Backend

* **Linguagem:** C\#
* **Framework:** .NET
* **ORM:** Entity Framework Core
* **Banco de Dados:** SQLite
* **API:** ASP.NET Core Web API
* **Documentação da API:** Swagger/OpenAPI

### Frontend

* **Linguagem:** TypeScript
* **Framework:** React
* **Roteamento:** React Router
* **Comunicação com a API:** Fetch API

## Arquitetura do Projeto
├── HotelAPI/             # Código da API em C# (.NET)<br>
│   ├── Controllers/<br>
│   ├── Migrations/<br>
│   ├── Models/<br>
│   ├── ...<br>
│   ├── HotelAPI.csproj<br>
│   └── Program.cs<br>
│<br>
└── hotel-frontend/            # Código do frontend em React e TypeScript<br>
├── public/<br>
|├── index.html<br>
├── src/<br>
│   ├── components/<br>
│   ├── App.tsx<br>
└── tsconfig.json<br>

## Pré-requisitos

Antes de executar o projeto, você precisará ter as seguintes ferramentas instaladas em sua máquina:

### Backend

* [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0 é a mínima necessária)

### Frontend

* [Node.js](https://nodejs.org/)
* [npm](https://www.npmjs.com/)

## Como Executar

Siga estas instruções para executar o projeto em seu ambiente local:

### Backend (API em C\#)

1.  Navegue até o diretório `HotelAPI` no seu terminal:
    ```bash
    cd HotelAPI
    ```
2.  Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```
3.  Execute a API:
    ```bash
    dotnet run
    ```
    A API estará disponível em um endereço como `http://localhost:[porta]` (verifique a saída do terminal).
4.  **Documentação da API (Swagger):** Se configurado, a documentação da API Swagger estará acessível em um endereço como `http://localhost:[porta]/swagger`.

### Frontend (React e TypeScript)

1.  Navegue até o diretório `hotel-frontend` em outro terminal:
    ```bash
    cd hotel-frontend
    ```
2.  Instale as dependências do projeto:
    ```bash
    npm install
    ```
3.  Execute a aplicação frontend em modo de desenvolvimento:
    ```bash
    npm run start
    ```
    A aplicação frontend estará disponível em um endereço como `http://localhost:[outra-porta]` (geralmente `3000` ou `5173`, dependendo da sua configuração).


## Licença

Este projeto está sob a licença [MIT](https://opensource.org/licenses/MIT).
