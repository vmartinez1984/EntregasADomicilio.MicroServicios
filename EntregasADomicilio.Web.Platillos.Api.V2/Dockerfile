#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=runtime
WORKDIR /src
COPY ["EntregasADomicilio.Web.Platillos.Api.V2/EntregasADomicilio.Web.Platillos.Api.V2.csproj", "EntregasADomicilio.Web.Platillos.Api.V2/"]
COPY ["EntregasADomiclio.StoreFilesLocal/EntregasADomicilio.StoreFiles.csproj", "EntregasADomiclio.StoreFilesLocal/"]
RUN dotnet restore "./EntregasADomicilio.Web.Platillos.Api.V2/EntregasADomicilio.Web.Platillos.Api.V2.csproj"
COPY . .
WORKDIR "/src/EntregasADomicilio.Web.Platillos.Api.V2"
RUN dotnet build "./EntregasADomicilio.Web.Platillos.Api.V2.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=runtime
RUN dotnet publish "./EntregasADomicilio.Web.Platillos.Api.V2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntregasADomicilio.Web.Platillos.Api.V2.dll"]