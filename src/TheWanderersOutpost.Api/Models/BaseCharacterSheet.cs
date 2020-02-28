using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace TheWanderersOutpost.Api.Models
{
    public class BaseCharacterSheet : ICharacterSheet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRequired]
        public string OwnerID { get; set; }
        [BsonRequired]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime _created { get; set; }
        [BsonRequired]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime _lastUpdated { get; set; }

        [BsonRequired]
        public string GameSystem => GetType().Name;
    }
}
