using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GroupmeBot.Data.Mongo.Models
{
    public abstract class MongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
