#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#ARG BUILD_CONFIGURATION=Release
ARG BUILD_CONFIGURATION=runtime
WORKDIR /src
COPY ["/EntregasADomicilio.Usuarios.Api/EntregasADomicilio.Usuarios.Api.csproj", "/EntregasADomicilio.Usuarios.Api/"]
COPY ["EntregasADomicilio.Usuarios.BusinessLayer/EntregasADomicilio.Usuarios.BusinessLayer.csproj", "EntregasADomicilio.Usuarios.BusinessLayer/"]
COPY ["EntregasADomicilio.Usuarios.Core/EntregasADomicilio.Usuarios.Core.csproj", "EntregasADomicilio.Usuarios.Core/"]
COPY ["EntregasADomicilio.Clientes.Repositorios.FiresStore/EntregasADomicilio.Usuarios.Repositorios.Firestore.Clientes.csproj", "EntregasADomicilio.Clientes.Repositorios.FiresStore/"]
COPY ["EntregasADomicilio.Usuarios.Repositorios.Firestore.Login/EntregasADomicilio.Usuarios.Repositorios.Firestore.Login.csproj", "EntregasADomicilio.Usuarios.Repositorios.Firestore.Login/"]
COPY ["EntregasADomicilio.Usuarios.Repositorios.Firestore.Usuarios/EntregasADomicilio.Usuarios.Repositorios.Firestore.Usuarios.csproj", "EntregasADomicilio.Usuarios.Repositorios.Firestore.Usuarios/"]
COPY ["JwtTokenService/JwtTokenService.csproj", "JwtTokenService/"]
RUN dotnet restore "./EntregasADomicilio.Usuarios.Api/EntregasADomicilio.Usuarios.Api.csproj"
COPY . .
WORKDIR "/src/EntregasADomicilio.Usuarios.Api"
RUN dotnet build "./EntregasADomicilio.Usuarios.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
ARG BUILD_CONFIGURATION=runtime
RUN dotnet publish "./EntregasADomicilio.Usuarios.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntregasADomicilio.Usuarios.Api.dll"]