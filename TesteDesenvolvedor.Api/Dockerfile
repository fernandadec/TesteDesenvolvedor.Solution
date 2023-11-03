#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TesteDesenvolvedor.Api/TesteDesenvolvedor.Api.csproj", "TesteDesenvolvedor.Api/"]
COPY ["TesteDesenvolvedor.Domain/TesteDesenvolvedor.Services.csproj", "TesteDesenvolvedor.Domain/"]
COPY ["TesteDesenvolvedor.Entities/TesteDesenvolvedor.Domain.csproj", "TesteDesenvolvedor.Entities/"]
COPY ["TesteDesenvolvedor.Infra/TesteDesenvolvedor.Infra.csproj", "TesteDesenvolvedor.Infra/"]
RUN dotnet restore "TesteDesenvolvedor.Api/TesteDesenvolvedor.Api.csproj"
COPY . .
WORKDIR "/src/TesteDesenvolvedor.Api"
RUN dotnet build "TesteDesenvolvedor.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteDesenvolvedor.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteDesenvolvedor.Api.dll"]