using GroupmeBot.Data.Mongo.Models;

namespace GroupmeBot.Data.Models.CustomCommands
{
    public class CustomCommandModel

    {
        public string MongoId { get; set; }
        public string CommandPrompt { get; set; }
        public string CommandResponse { get; set; }

        public CustomCommandModel() { }

        public CustomCommandModel(CustomCommand command)
        {
            MongoId = command.Id;
            CommandPrompt = command.CommandPrompt;
            CommandResponse = command.CommandResponse;
        }
    }
}
