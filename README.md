# AirQuality API 🍃⛅

Uma API RESTful robusta desenvolvida em **C# .NET**, projetada para monitoramento, coleta e paginação de dados climáticos e de qualidade do ar. 

Este projeto foi construído como um portfólio técnico para demonstrar a aplicação de padrões corporativos de desenvolvimento de software.

## 🏗️ Arquitetura e Padrões

O projeto foi estritamente desenhado utilizando a **Clean Architecture (Arquitetura Limpa)**, garantindo nível de desacoplamento, testabilidade e facilidade de manutenção. A solução está dividida em quatro camadas principais:

* **API (Presentation):** Controladores enxutos, injeção de dependências e documentação via Swagger. Tratamento centralizado de exceções para respostas HTTP amigáveis.
* **Application:** Regras de negócio isoladas, mapeamento de Entidades para DTOs (Data Transfer Objects) e orquestração de serviços.
* **Domain:** Contém as Entidades de negócio e as Interfaces (Contratos) dos repositórios.
* **Infrastructure:** Contexto do Entity Framework, persistência no PostgreSQL e consumo de APIs externas.

## 🚀 Principais Funcionalidades implementadas

* **Integração com APIs Externas:** Consumo resiliente da API pública *Open-Meteo* utilizando `IHttpClientFactory` nativo do .NET, com formatação global de cultura (`InvariantCulture`) e desserialização de JSON.
* **Paginação de Dados Nível Banco:** Implementação de listagem paginada (`Skip` e `Take`) traduzida diretamente para SQL pelo Entity Framework Core.
* **Idempotência e Guard Clauses:** Regras de negócio estritas que impedem a duplicação de medições para uma mesma localização no mesmo dia, garantindo a integridade dos dados no banco.
* **Design Orientado a DTOs:** Separação clara entre os dados que transitam na web e os dados que são gravados no banco, protegendo o modelo de domínio.

## 🛠️ Tecnologias Utilizadas

* **C# 12 / .NET 10**
* **Entity Framework Core** (ORM)
* **PostgreSQL** (Banco de Dados Relacional)
* **Swagger / OpenAPI** (Documentação interativa)
* **System.Text.Json** (Manipulação de JSON)

## ⚙️ Como Executar o Projeto

### Pré-requisitos
* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* [PostgreSQL](https://www.postgresql.org/download/) instalado e rodando.

### Passos

1. Clone este repositório:
   ```bash
   git clone [https://github.com/](https://github.com/)[SEU-USUARIO-GITHUB]/AirQuality.git

2. Acesse a pasta do projeto da API:
   ```bash
   cd AirQuality/AirQuality.API

3. Configure a sua string de conexão com o PostgreSQL no arquivo appsettings.json

4. Restaure as dependências e aplique as Migrations para criar o banco de dados:
   ```bash
   dotnet restore
   dotnet ef database update --project ../AirQuality.Infrastructure --startup-project .

5. Execute a aplicação

6. Acesse o Swagger no seu navegador através da URL fornecida no terminal
