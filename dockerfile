FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["mssqlWithDocker.csproj", "."]
RUN dotnet restore "./mssqlWithDocker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "mssqlWithDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mssqlWithDocker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mssqlWithDocker.dll"]