# استفاده از تصویر پایه ASP.NET Core 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# استفاده از .NET SDK برای ساخت برنامه
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "BookStore.WebUI/BookStore.WebUI.csproj"
RUN dotnet publish "BookStore.WebUI/BookStore.WebUI.csproj" -c Release -o /app/publish

# ساخت تصویر نهایی برای اجرا
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BookStore.WebUI.dll"]


