## Documentação para Dockerização da Aplicação

Este documento fornece um guia passo a passo sobre como preparar e dockerizar sua aplicação C#. O processo consiste em criar arquivos Docker específicos, configurar o docker-compose e ajustar as rotas dentro dos serviços da aplicação.

### 1. Docker-compose
Localize o arquivo `docker-compose.yml` na pasta inicial do projeto. Este arquivo é responsável por orquestrar todos os containers necessários para sua aplicação.

#### Conteúdo básico do `docker-compose.yml`:
```dockerfile
version: '3'

services:
  modulo_usuario:
    build:
      context: ./path_to_user_api
      dockerfile: Dockerfile
    ports:
      - "8080:80"

  modulo_empresa:
    build:
      context: ./path_to_company_api
      dockerfile: Dockerfile
    ports:
      - "8081:80"

  modulodb:
    build:
      context: ./path_to_db_api
      dockerfile: Dockerfile
    ports:
      - "7119:80"

networks:
  default:
    external:
      name: my-net
```

**Notas**:
- O formato de portas "8080:80" indica que a porta 8080 do seu localhost será mapeada para a porta 80 do container.
- Certifique-se de ajustar os caminhos (`./path_to_user_api`, etc.) para os diretórios corretos da sua aplicação.
- Estamos usando uma rede externa chamada `my-net`. Se preferir criar uma rede no formato bridge, substitua a seção de redes conforme necessário.

### 2. Dockerfile
Cada aplicação (módulo) em C# precisa de seu próprio Dockerfile. Este arquivo descreve como construir a imagem do Docker para a aplicação.

#### Exemplo de `Dockerfile`:
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyApp/MyApp.csproj", "MyApp/"]
RUN dotnet restore "MyApp/MyApp.csproj"
COPY . .
WORKDIR "/src/MyApp"
RUN dotnet build "MyApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApp.dll"]
```

**Notas**:
- Certifique-se de ajustar "MyApp/MyApp.csproj" e "MyApp.dll" para o nome correto do seu projeto.
- O comando `EXPOSE 80` define que a aplicação estará escutando na porta 80 dentro do container.

### 3. Ajuste de Rotas em C#
As rotas da API precisam ser ajustadas para se comunicar corretamente entre os containers. Em vez de usar `localhost`, use o nome do serviço definido no `docker-compose.yml`.

**Por exemplo**:
Mude de:
```csharp
"http://localhost:7119/api/UserApp/User/{id}"
```
Para:
```csharp
"http://modulodb/api/UserApp/User/{id}"
```

Neste exemplo, `modulodb` é o nome do serviço (container) que hospeda a API do banco de dados.

---

Com essas instruções, você deve ser capaz de dockerizar e orquestrar sua aplicação C# com sucesso. Lembre-se de testar tudo em um ambiente de desenvolvimento antes de fazer o deploy em produção. Boa sorte!
