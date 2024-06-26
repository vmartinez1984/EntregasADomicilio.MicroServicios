#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=runtime
WORKDIR /src
COPY ["EntregasADomicilio.Web.ApiGateway/EntregasADomicilio.Web.ApiGateway.csproj", "EntregasADomicilio.Web.ApiGateway/"]
COPY ["JwtTokenService/JwtTokenService.csproj", "JwtTokenService/"]
RUN dotnet restore "./EntregasADomicilio.Web.ApiGateway/EntregasADomicilio.Web.ApiGateway.csproj"
COPY . .
WORKDIR "/src/EntregasADomicilio.Web.ApiGateway"
RUN dotnet build "./EntregasADomicilio.Web.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=runtime
RUN dotnet publish "./EntregasADomicilio.Web.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntregasADomicilio.Web.ApiGateway.dll"]