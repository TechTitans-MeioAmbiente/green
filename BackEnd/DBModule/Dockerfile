# Use a imagem base do ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY ["appsettings.json", "appsettings.json"]
EXPOSE 5008
#aqui é por onde faremos requisições  mas a 5008 é onde expôs
EXPOSE 80 
EXPOSE 51759

# Use a imagem base do SDK do ASP.NET Core para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TechTitansAPI.csproj", "TechTitansAPI.csproj"]
RUN dotnet restore "TechTitansAPI.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "TechTitansAPI.csproj" -c Release -o /app/build

# Publica o aplicativo
FROM build AS publish
RUN dotnet publish "TechTitansAPI.csproj" -c Release -o /app/publish

# Cria a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechTitansAPI.dll"]