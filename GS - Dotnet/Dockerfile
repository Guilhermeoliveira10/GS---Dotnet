# Use a imagem oficial do .NET para o ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Utilize a imagem para compilar o .NET
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
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

# Defina o contêiner final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SafeZone.API.dll"]
