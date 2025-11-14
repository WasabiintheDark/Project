# ===== СТАДИЯ СБОРКИ =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем все файлы решения внутрь контейнера
COPY . .

# Восстанавливаем зависимости
RUN dotnet restore CompanyWorkload.sln

# Публикуем API в Release
WORKDIR /src/src/CompanyWorkload.Api
RUN dotnet publish CompanyWorkload.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

# ===== СТАДИЯ РАНТАЙМА =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Копируем опубликованные файлы
COPY --from=build /app/publish .

# Слушаем порт 8080 внутри контейнера
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CompanyWorkload.Api.dll"]
