FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 3010

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/dndChar.mvc/dndChar.mvc.csproj src/dndChar.mvc/
COPY src/dndChar.Database/dndChar.Database.csproj src/dndChar.Database/
COPY src/dndChar/dndChar.csproj src/dndChar/
RUN dotnet restore src/dndChar.mvc/dndChar.mvc.csproj
COPY . .
WORKDIR /src/src/dndChar.mvc
RUN dotnet build dndChar.mvc.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish dndChar.mvc.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dndChar.mvc.dll"]
