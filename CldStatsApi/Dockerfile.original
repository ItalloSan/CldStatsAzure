#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CldStatsApi/CldStatsApi.csproj", "CldStatsApi/"]
RUN dotnet restore "CldStatsApi/CldStatsApi.csproj"
COPY . .
WORKDIR "/src/CldStatsApi"
RUN dotnet build "CldStatsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CldStatsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CldStatsApi.dll"]