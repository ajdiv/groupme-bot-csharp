# Groupme Chat Bot

This Groupme chat bot is made to add additional functionality to Groupme via text commands similar to Slack or Discord.

This app is built with a .NET Core (3.1) API and is intended to be deployed using Docker. 

## Deploying with Heroku
This app was initially created with the intent of using completely free development resources. Heroku has a free tier that has sufficient usage thresholds that fit these requirements.

Once your app is set up in Heroku, you must build an image in Docker (see [Using Docker](#using-docker) section below) and then tag it to your remote Heroku instance by doing the following. Replace `boytz-bot-csharp` with your Heroku app name:
```
docker tag boyz-bot-csharp registry.heroku.com/boyz-bot-csharp/web
```

You can push and deploy your container using the following, replacing `boyz-bot-csharp` with your Heroku app name.

Push Docker container to Heroku:
```
heroku container:push web -a boyz-bot-csharp
```
Deploy Docker container to Heroku:
```
heroku container:release web -a boyz-bot-csharp
```
Viewing logs on deployed Heroku instance:
```
heroku logs --tail -a boyz-bot-csharp
```
## Using Docker <a name="using-docker"></a>
Install [Docker Desktop](https://docs.docker.com/desktop/)
All Docker commands should be run at the solution (root) folder.
Build Docker images using the following command (replace `boyz-bot-csharp` with your desired app name):
```
docker build -t boyz-bot-csharp . 
```
Deployment of your Docker image depends on where you are hosting the code. 
