# AirQuality API 🍃⛅

API RESTful desenvolvida em C# .NET para monitoramento, coleta e paginação de dados climáticos e de qualidade do ar, com foco em eficiência, escalabilidade e boas práticas de arquitetura.

O projeto foi concebido como portfólio técnico, demonstrando a aplicação de padrões utilizados em ambientes corporativos, como Clean Architecture, consumo resiliente de APIs externas, paginação eficiente em banco de dados e separação de responsabilidades entre camadas.

## 🏗️ Arquitetura e Padrões

O projeto foi estruturado com base na Clean Architecture, priorizando baixo acoplamento, alta testabilidade e facilidade de manutenção. A solução está organizada em quatro camadas principais:

* **API (Presentation):** responsável pela exposição dos endpoints, com controladores enxutos, uso de injeção de dependência e documentação via Swagger. Possui tratamento centralizado de exceções para padronização das respostas HTTP.
* **Application:** concentra os casos de uso da aplicação, orquestrando as regras de negócio, realizando o mapeamento entre entidades e DTOs e coordenando os serviços.
* **Domain:** núcleo da aplicação, contendo as entidades de negócio e os contratos (interfaces) que definem o comportamento esperado dos repositórios.
* **Infrastructure:** implementação dos detalhes técnicos, incluindo o contexto do Entity Framework, persistência no PostgreSQL e integrações com APIs externas.

## 🚀 Principais Funcionalidades implementadas

* **Integração com APIs externas:** implementação de consumo resiliente da API pública Open-Meteo via IHttpClientFactory, incluindo políticas de retry e timeout, padronização de cultura com InvariantCulture para consistência de dados e desserialização tipada de JSON.
* **Paginação de dados no banco:** utilização de paginação eficiente com Skip e Take, traduzida diretamente para SQL pelo Entity Framework Core, evitando sobrecarga na aplicação.
* **Validação de regras:** aplicação de guard clauses e regras de negócio que impedem a duplicação de medições para a mesma localização no mesmo dia, garantindo integridade dos dados.
* **Design orientado a DTOs:** separação entre os dados expostos na camada de API e o modelo de domínio, promovendo baixo acoplamento e maior segurança na persistência.

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
