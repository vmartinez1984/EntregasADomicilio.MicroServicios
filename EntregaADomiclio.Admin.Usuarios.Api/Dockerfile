#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EntregaADomiclio.Admin.Usuarios.Api/EntregaADomicilio.Admin.Usuarios.Api.csproj", "EntregaADomiclio.Admin.Usuarios.Api/"]
RUN dotnet restore "./EntregaADomiclio.Admin.Usuarios.Api/EntregaADomicilio.Admin.Usuarios.Api.csproj"
COPY . .
WORKDIR "/src/EntregaADomiclio.Admin.Usuarios.Api"
RUN dotnet build "./EntregaADomicilio.Admin.Usuarios.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EntregaADomicilio.Admin.Usuarios.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntregaADomicilio.Admin.Usuarios.Api.dll"]