using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace dndCharApi.Models
{
    public class BaseCharacterSheet : ICharacterSheet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRequired]
        public string OwnerID { get; set; }
        [BsonRequired]
        public BsonDateTime _created { get; set; }
        [BsonRequired]
        public BsonDateTime _lastUpdated { get; set; }

        [BsonRequired]
        public string GameSystem => GetType().Name;
    }
}
