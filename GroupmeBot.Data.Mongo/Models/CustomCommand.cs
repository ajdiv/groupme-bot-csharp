using MongoDB.Bson.Serialization.Attributes;

namespace GroupmeBot.Data.Mongo.Models
{
    [BsonIgnoreExtraElements]
    public class CustomCommand : MongoModel
    {
        public string CommandPrompt { get; set; }
        public string CommandResponse { get; set; }
    }
}
