# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PruebaTecnica.API/PruebaTecnica.API.csproj", "PruebaTecnica.API/"]
COPY ["PruebaTecnica.Data/PruebaTecnica.Data.csproj", "PruebaTecnica.Data/"]
COPY ["PruebaTecnica.Logica/PruebaTecnica.Logica.csproj", "PruebaTecnica.Logica/"]
RUN dotnet restore "./PruebaTecnica.API/PruebaTecnica.API.csproj"
COPY . .
WORKDIR "/src/PruebaTecnica.API"
RUN dotnet build "./PruebaTecnica.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PruebaTecnica.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaTecnica.API.dll"]