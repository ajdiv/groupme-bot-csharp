#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

# Don't expose any ports because Heroku will handle them for us
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GroupmeBot.Api/GroupmeBot.Api.csproj", "GroupmeBot.Api/"]
RUN dotnet restore "GroupmeBot.Api/GroupmeBot.Api.csproj"
COPY . .
WORKDIR "/src/GroupmeBot.Api"
RUN dotnet build "GroupmeBot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroupmeBot.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupmeBot.Api.dll"]