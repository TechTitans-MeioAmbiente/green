# Use a imagem base do ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY ["appsettings.json", "appsettings.json"]
EXPOSE 8082

# Use a imagem base do SDK do ASP.NET Core para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CompanyModule.csproj", "CompanyModule.csproj"]
RUN dotnet restore "CompanyModule.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "CompanyModule.csproj" -c Release -o /app/build

# Publica o aplicativo
FROM build AS publish
RUN dotnet publish "CompanyModule.csproj" -c Release -o /app/publish

# Cria a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyModule.dll"]