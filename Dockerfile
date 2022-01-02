#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

# Don't expose any ports because Heroku will handle them for us
#EXPOSE 80
#EXPOSE 443
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["GroupmeBot.Api/GroupmeBot.Api.csproj", "GroupmeBot.Api/"]
COPY ["GroupmeBot.WebHelpers/GroupmeBot.WebHelpers.csproj", "GroupmeBot.WebHelpers/"]
COPY ["GroupmeBot.Data/GroupmeBot.Data.csproj", "GroupmeBot.Data/"]
RUN dotnet restore "GroupmeBot.Api/GroupmeBot.Api.csproj"
COPY . .
WORKDIR "/src/GroupmeBot.Api"
RUN dotnet build "GroupmeBot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroupmeBot.Api.csproj" -c Release -o /app/publish

FROM node as nodebuilder
RUN mkdir /usr/src/app
WORKDIR /usr/src/app
#ENV PATH /usr/src/app/node_modules/.bin:$PATH
COPY GroupmeBot.Api/ClientApp/package.json /usr/src/app/package.json
RUN export NODE_OPTIONS=--openssl-legacy-provider && npm install --save --legacy-peer-deps
COPY GroupmeBot.Api/ClientApp/. /usr/src/app
RUN export NODE_OPTIONS=--openssl-legacy-provider && npm run build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir -p /app/dist
COPY --from=nodebuilder /usr/src/app/dist/. /app/ClientApp/dist/
ENTRYPOINT ["dotnet", "GroupmeBot.Api.dll"]