FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52925
EXPOSE 44316

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY dndChar.Api/dndChar.Api.csproj dndChar.Api/
RUN dotnet restore dndChar.Api/dndChar.Api.csproj
COPY . .
WORKDIR /src/dndChar.Api
RUN dotnet build dndChar.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish dndChar.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dndChar.Api.dll"]
