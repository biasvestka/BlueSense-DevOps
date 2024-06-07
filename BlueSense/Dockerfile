# Usar a imagem oficial do .NET SDK para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Variáveis de build
ARG BUILD_CONFIGURATION=Release
ENV ASPNETCORE_ENVIRONMENT=Development

# Copiar o arquivo .csproj e restaurar as dependências
COPY BlueSense.csproj ./BlueSense/
RUN dotnet restore ./BlueSense/BlueSense.csproj

# Copiar o restante do código da aplicação e construir a release
COPY . ./BlueSense/
WORKDIR /app/BlueSense
RUN dotnet publish -c $BUILD_CONFIGURATION -o out

# Usar a imagem oficial do ASP.NET Core runtime otimizada para produção
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Adicionar um usuário não root
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Copiar os binários da aplicação do estágio de build
COPY --from=build /app/BlueSense/out .

# Persistir dados no volume (opcional)
VOLUME ["/app/data"]

ENTRYPOINT ["dotnet", "BlueSense.dll"]
