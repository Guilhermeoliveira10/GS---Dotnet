# Use a imagem oficial do .NET para o ASP.NET Core com .NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Utilize a imagem para compilar o .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o projeto .csproj para dentro do contêiner
COPY ["SafeZone.API/SafeZone.API.csproj", "SafeZone.API/"]
RUN dotnet restore "SafeZone.API/SafeZone.API.csproj"

# Copie todo o restante do código para dentro do contêiner
COPY . . 

# Configure a pasta de trabalho para o projeto da API
WORKDIR "/src/SafeZone.API"

# Compile e publique a aplicação
RUN dotnet build "SafeZone.API.csproj" -c Release -o /app/build
RUN dotnet publish "SafeZone.API.csproj" -c Release -o /app/publish

# Defina o contêiner final (utilize a imagem ASP.NET Core de runtime com .NET 8.0)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copie os arquivos da etapa de build/publish para a etapa final
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SafeZone.API.dll"]
