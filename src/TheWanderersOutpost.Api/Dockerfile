#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TheWanderersOutpost.Api/TheWanderersOutpost.Api.csproj", "src/TheWanderersOutpost.Api/"]
COPY ["src/TheWanderersOutpost.Api.Database/TheWanderersOutpost.Api.Database.csproj", "src/TheWanderersOutpost.Api.Database/"]
RUN dotnet restore "src/TheWanderersOutpost.Api/TheWanderersOutpost.Api.csproj"
COPY . .
WORKDIR "/src/src/TheWanderersOutpost.Api"
RUN dotnet build "TheWanderersOutpost.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheWanderersOutpost.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheWanderersOutpost.Api.dll"]