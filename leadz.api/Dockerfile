FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY leadz.api/Leadz.Api.csproj leadz.api/
RUN dotnet restore leadz.api/Leadz.Api.csproj
COPY . .
WORKDIR /src/leadz.api
RUN dotnet build Leadz.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Leadz.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Leadz.Api.dll"]
