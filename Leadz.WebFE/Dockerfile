FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Leadz.WebFE/Leadz.WebFE.csproj Leadz.WebFE/
RUN dotnet restore Leadz.WebFE/Leadz.WebFE.csproj
COPY . .
WORKDIR /src/Leadz.WebFE
RUN dotnet build Leadz.WebFE.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Leadz.WebFE.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Leadz.WebFE.dll"]
