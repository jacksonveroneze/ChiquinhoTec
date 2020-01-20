# ChiquinhoTec - Gerenciador Contratação

API developed to be consulted in the ChiquinhoTec - Gerenciador Contratação application.

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

### Setup

  Online Demo: [https://jacksonveroneze.azurewebsites.net](https://jacksonveroneze.azurewebsites.net) in your client to consult the API or  
  [https://jacksonveroneze.azurewebsites.net/check](https://jacksonveroneze.azurewebsites.net/check) to consult the API health.

## Technologies
* C# .0
* .NET Core 3.1
* ASP.NET Core 3.1
* Entity Framework Core 3.1
* Application Insights
* CI/CD Azure DevOps
* OAuth2(Auth0 Service)

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/jacksonveroneze/Pharmacy-API/blob/develop/LICENSE) file for details.
