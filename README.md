# Groupme Chat Bot

This Groupme chat bot is made to add additional functionality to Groupme via text commands similar to Slack or Discord.

This app is built with a .NET Core (3.1) API and is intended to be deployed using Docker. 

## Deploying with Heroku
This app was initially created with the intent of using completely free development resources. Heroku has a free tier that has sufficient usage thresholds that fit these requirements.

Once your app is set up in Heroku, you must build an image in Docker (see [Using Docker](#using-docker) section below) and then tag it to your remote Heroku instance by doing the following:
```
docker tag your-app-name registry.heroku.com/heroku-app-name/web
```

You can push and deploy your container using the following, replacing `boyz-bot-csharp` with your Heroku app name.

Push Docker container to Heroku:
```
heroku container:push web -a heroku-app-name
```
Deploy Docker container to Heroku:
```
heroku container:release web -a heroku-app-name
```
Viewing logs on deployed Heroku instance:
```
heroku logs --tail -a heroku-app-name
```
## Using Docker <a name="using-docker"></a>
Install [Docker Desktop](https://docs.docker.com/desktop/)
All Docker commands should be run at the solution (root) folder.
Build Docker images using the following command:
```
docker build -t your-app-name . 
```
Deployment of your Docker image depends on where you are hosting the code. 

## Creating the GroupMe Bot<a name="bot"></a>

1. Set up a dev account on [https://dev.groupme.com/bots](https://dev.groupme.com/bots)
2. Go to "Bots" on the top navigation and create a new bot, following the prompts as needed. The Callback URL should correspond to the URL that your code is deployed to. 
If you are deploying to Heroku: https://heroku-app-name.herokuapp.com/

## Setting User Secrets <a name="using-secrets"></a>
Currently the BotApi project is using the .Net Core secret management system. To access the secrets and replace with your own, right click the project and select "Manage User Secrets".
Secrets user file should be formatted per the folloring:
```
{
  "GroupmeCreds": {
    "BotApiKey": "BOT_API_KEY_HERE"
  }
}
```

## Using Heroku<a name="heroku"></a>
Format the user secrets in Heroku in Settings => Reveal Config Vars  
```
Key Column: GroupmeCreds:BotApiKey
Value Column: BOT_API_KEY_HERE
```