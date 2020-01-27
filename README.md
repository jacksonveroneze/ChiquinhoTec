# ChiquinhoTec - Gerenciador Contratação

API developed to be consulted in the ChiquinhoTec - Gerenciador Contratação application.

[![Build Status](https://dev.azure.com/Jackson-Veroneze/ChiquinhoTec.GerenciadorContratacao/_apis/build/status/Deploy%20Azure%20Web%20App%20for%20ASP.NET-CI?branchName=master)](https://dev.azure.com/Jackson-Veroneze/ChiquinhoTec.GerenciadorContratacao/_build/latest?definitionId=1&branchName=master)

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017/2019](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 3.1](https://www.microsoft.com/net/download/dotnet-core/2.2)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  
  2. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  3. Up db container:
     ```
     docker-compose up -d db
     ```
  4. Execute migrations:
     ```
     dotnet ef database update
     ```
  5. Run application:
     ```
	 dotnet run 
     ```
  5. Launch local [http://localhost:5000/](http://localhost:5000/) in your client to consult the API or  
     [http://localhost:5000/check](http://localhost:5000/check) to consult the API health.

### We are Online:

See the project running on Azure

Online Demo: [https://jacksonveroneze.azurewebsites.net](https://jacksonveroneze.azurewebsites.net) in your client to consult the API or  
  [https://jacksonveroneze.azurewebsites.net/check](https://jacksonveroneze.azurewebsites.net/check) to consult the API health.
  
### Blazemeter
Performance: [https://a.blazemeter.com/app/?public-token=UITkCloLEfduaYkJ54E1EpKZaXwYGE2eJFrdSvSeYXFYUdmn28#/accounts/415846/workspaces/414620/projects/506690/masters/25059817/summary](https://a.blazemeter.com/app/?public-token=UITkCloLEfduaYkJ54E1EpKZaXwYGE2eJFrdSvSeYXFYUdmn28#/accounts/415846/workspaces/414620/projects/506690/masters/25059817/summary)

## Technologies:

- C# 8.0
- ASP.NET Core 3.1
- ASP.NET MVC Core 
- ASP.NET WebApi Core with JWT Bearer Authentication
- Entity Framework Core 3.1
- .NET Core Native DI
- AutoMapper
- FluentValidator
- Postgres 12
- Application Insights
- CI/CD Azure DevOps
- OAuth2(Auth0 Service)
- GraphQL

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/jacksonveroneze/Pharmacy-API/blob/develop/LICENSE) file for details.
