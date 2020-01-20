FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

RUN ln -s /opt/dotnet/dotnet /usr/sbin/dotnet

WORKDIR /application

COPY . /application

RUN dotnet restore

RUN dotnet publish -c Release -o /application/output

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base

RUN ln -s /opt/dotnet/dotnet /usr/sbin/dotnet

WORKDIR /application

COPY --from=build-env /application/output .

RUN ls .

ENTRYPOINT ["dotnet", "ChiquinhoTec.GerenciadorContratacao.Api.dll"]