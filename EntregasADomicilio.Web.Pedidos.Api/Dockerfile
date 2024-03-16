#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EntregasADomicilio.Web.Pedidos.Api/EntregasADomicilio.Web.Pedidos.Api.csproj", "EntregasADomicilio.Web.Pedidos.Api/"]
COPY ["JwtTokenService/JwtTokenService.csproj", "JwtTokenService/"]
COPY ["EntregasADomicilio.Web.Pedidos.BusinessLayer/EntregasADomicilio.Web.Pedidos.BusinessLayer.csproj", "EntregasADomicilio.Web.Pedidos.BusinessLayer/"]
COPY ["EntregasADomicilio.Web.Pedidos.Core/EntregasADomicilio.Web.Pedidos.Core.csproj", "EntregasADomicilio.Web.Pedidos.Core/"]
COPY ["EntregasADomicilio.Web.Pedidos.Platillos.Servicios/EntregasADomicilio.Web.Pedidos.Servicios.csproj", "EntregasADomicilio.Web.Pedidos.Platillos.Servicios/"]
COPY ["EntregasADomicilio.Web.Pedidos.Servicios/EntregasADomicilio.Web.Pedidos.Repositorios.Firestore.csproj", "EntregasADomicilio.Web.Pedidos.Servicios/"]
RUN dotnet restore "./EntregasADomicilio.Web.Pedidos.Api/EntregasADomicilio.Web.Pedidos.Api.csproj"
COPY . .
WORKDIR "/src/EntregasADomicilio.Web.Pedidos.Api"
RUN dotnet build "./EntregasADomicilio.Web.Pedidos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EntregasADomicilio.Web.Pedidos.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntregasADomicilio.Web.Pedidos.Api.dll"]