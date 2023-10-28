# Use a imagem base do ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY ["appsettings.json", "appsettings.json"]
EXPOSE 8081

# Use a imagem base do SDK do ASP.NET Core para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UserAPI.csproj", "UserAPI.csproj"]
RUN dotnet restore "UserAPI.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "UserAPI.csproj" -c Release -o /app/build

# Publica o aplicativo
FROM build AS publish
RUN dotnet publish "UserAPI.csproj" -c Release -o /app/publish

# Cria a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAPI.dll"]