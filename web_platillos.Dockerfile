#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../EntregasADomicilio.Web.Platillos/EntregasADomicilio.Web.Platillos.Api.csproj", "EntregasADomicilio.Web.Platillos/"]
COPY ["../EntregasADomicilio.Web.Repositorios.Sql/EntregasADomicilio.Web.Platillos.Repositorios.Sql.csproj", "EntregasADomicilio.Web.Repositorios.Sql/"]
RUN dotnet restore "./EntregasADomicilio.Web.Platillos/EntregasADomicilio.Web.Platillos.Api.csproj"
COPY . .
WORKDIR "/src/EntregasADomicilio.Web.Platillos"
#RUN dotnet build "./EntregasADomicilio.Web.Platillos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "./EntregasADomicilio.Web.Platillos.Api.csproj" -c runtime -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./EntregasADomicilio.Web.Platillos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "./EntregasADomicilio.Web.Platillos.Api.csproj" -c runtime -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntregasADomicilio.Web.Platillos.Api.dll"]

# docker build -t ead_web_platillos_v1 -f Dockerfile .