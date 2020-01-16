FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env

WORKDIR /application

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o /application/output

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine

WORKDIR /application

COPY --from=build-env /application/output .

ENTRYPOINT ["dotnet", "JacksonVeroneze.Pharmacy.Api.dll"]