using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

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
#pragma warning disable IDE1006 // Naming Styles
        public BsonDateTime _created { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        [BsonRequired]
#pragma warning disable IDE1006 // Naming Styles
        public BsonDateTime _lastUpdated { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        [BsonRequired]
        public string GameSystem => GetType().Name;
    }
}
