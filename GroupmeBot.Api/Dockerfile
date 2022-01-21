FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /build

RUN curl -sL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs

COPY ["GroupmeBot.Api/GroupmeBot.Api.csproj", "GroupmeBot.Api/"]
RUN dotnet restore "GroupmeBot.Api/GroupmeBot.Api.csproj"

COPY . .
WORKDIR /build
RUN dotnet publish "GroupmeBot.Api/GroupmeBot.Api.csproj" -c Release -o published --no-cache

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /build/published ./
ENTRYPOINT ["dotnet", "GroupmeBot.Api.dll"]