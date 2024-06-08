# Stage de build
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app
ENV PATH="$PATH:/usr/share/dotnet"

# Instala a ferramenta dotnet-ef globalmente
RUN dotnet tool install --global dotnet-ef --version 8.0.6

ARG BUILD_CONFIGURATION=Release

# Copia o arquivo de projeto e restaura as dependências
COPY BlueSense.csproj ./BlueSense/
RUN dotnet restore ./BlueSense/BlueSense.csproj

# Copia o restante do código e faz o build
COPY . ./BlueSense/
WORKDIR /app/BlueSense
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/out

# Stage de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Instala a ferramenta dotnet-ef globalmente
# RUN dotnet tool install --global dotnet-ef --version 8.0.6

# Adiciona um usuário não root
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app

# Configura o diretório para as chaves de proteção de dados e ajusta permissões
RUN mkdir -p /home/appuser/.aspnet/DataProtection-Keys \
    && chown -R appuser /home/appuser/.aspnet

USER appuser

# Configura a URL de escuta
ENV ASPNETCORE_URLS=http://+:5232

# Copia os binários da aplicação do stage de build
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "BlueSense.dll"]
