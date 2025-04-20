FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj and restore
COPY ["ProductsServices/ProductsServices.csproj", "ProductsServices/"]
RUN dotnet restore "ProductsServices/ProductsServices.csproj"

# Copy rest of the files
COPY . .
WORKDIR "/src/ProductsServices"

# Use $BUILD_CONFIGURATION (not %BUILD_CONFIGURATION%)
RUN dotnet build "ProductsServices.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductsServices.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsServices.dll"]
