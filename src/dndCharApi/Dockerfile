#Set up env
ENV MongoConfig.Url='123123123'

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/dndCharApi/dndCharApi.csproj", "src/dndCharApi/"]
COPY ["src/dndChar.Database/dndChar.Database.csproj", "src/dndChar.Database/"]
RUN dotnet restore "src/dndCharApi/dndCharApi.csproj"
COPY . .
WORKDIR "/src/src/dndCharApi"
RUN dotnet build "dndCharApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dndCharApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dndCharApi.dll"]