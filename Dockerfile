#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

# Don't expose any ports because Heroku will handle them for us
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["BotApi/BotApi.csproj", "BotApi/"]
RUN dotnet restore "BotApi/BotApi.csproj"
COPY . .
WORKDIR "/src/BotApi"
RUN dotnet build "BotApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BotApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BotApi.dll"]