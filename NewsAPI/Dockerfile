FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NewsAPI/NewsAPI.csproj", "NewsAPI/"]
COPY ["NewsRepository/NewsRepository.csproj", "NewsRepository/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["NewsService/NewsService.csproj", "NewsService/"]
RUN dotnet restore "NewsAPI/NewsAPI.csproj"
COPY . .
WORKDIR "/src/NewsAPI"
RUN dotnet build "NewsAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NewsAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsAPI.dll"]
