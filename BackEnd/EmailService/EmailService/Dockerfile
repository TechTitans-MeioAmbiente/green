# Use a imagem base do ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8082
EXPOSE 80

# Use a imagem base do SDK do ASP.NET Core para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmailService.csproj", "EmailService.csproj"]
RUN dotnet restore "EmailService.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "EmailService.csproj" -c Release -o /app/build

# Publica o aplicativo
FROM build AS publish
RUN dotnet publish "EmailService.csproj" -c Release -o /app/publish

# Cria a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailService.dll"]