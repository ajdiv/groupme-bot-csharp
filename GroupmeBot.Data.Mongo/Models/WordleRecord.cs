using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GroupmeBot.Data.Mongo.Models
{
    [BsonIgnoreExtraElements]
    public class WordleRecord : MongoModel
    {
        public int DailySubmissionIdentifier { get; set; }
        public int SolvedInAttempts { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string UserId { get; set; }
    }
}
