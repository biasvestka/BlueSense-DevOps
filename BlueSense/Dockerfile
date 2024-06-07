# Usar a imagem oficial do .NET SDK para construir a aplica��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Vari�veis de build
ARG BUILD_CONFIGURATION=Release
ENV ASPNETCORE_ENVIRONMENT=Development

# Copiar o arquivo .csproj e restaurar as depend�ncias
COPY BlueSense.csproj ./BlueSense/
RUN dotnet restore ./BlueSense/BlueSense.csproj

# Copiar o restante do c�digo da aplica��o e construir a release
COPY . ./BlueSense/
WORKDIR /app/BlueSense
RUN dotnet publish -c $BUILD_CONFIGURATION -o out

# Usar a imagem oficial do ASP.NET Core runtime otimizada para produ��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Adicionar um usu�rio n�o root
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Copiar os bin�rios da aplica��o do est�gio de build
COPY --from=build /app/BlueSense/out .

# Persistir dados no volume (opcional)
VOLUME ["/app/data"]

ENTRYPOINT ["dotnet", "BlueSense.dll"]