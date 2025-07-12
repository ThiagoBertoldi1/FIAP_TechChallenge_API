# Fase de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo de projeto e restaurar dependências
COPY ["TechChallenge.API/TechChallenge.API.csproj", "TechChallenge.API/"]
RUN dotnet restore "TechChallenge.API/TechChallenge.API.csproj"

# Copiar o restante dos arquivos e construir
COPY . . 
WORKDIR "/src/TechChallenge.API"
RUN dotnet build "TechChallenge.API.csproj" -c Debug -o /app/build

# Publicar a aplicação
RUN dotnet publish "TechChallenge.API.csproj" -c Debug -o /app/publish

# Fase final - imagem para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expor a porta para acessar via HTTP
EXPOSE 80

# Definir o ponto de entrada
ENTRYPOINT ["dotnet", "TechChallenge.API.dll"]
