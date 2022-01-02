﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GroupmeBot.Data.Mongo.Models
{
    [BsonIgnoreExtraElements]
    public class Spew
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("gmeUserId")]
        public int GroupmeUserId { get; set; }

        [BsonElement("spewCount")]
        public int SpewCount { get; set; }

        [BsonElement("spewDate")]
        public DateTime SpewDate { get; set; }
    }
}
