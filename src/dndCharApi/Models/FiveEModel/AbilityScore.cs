using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dndCharApi.Models.RpgChar
{
    public class AbilityScore
    {
        [BsonRepresentation(BsonType.Int32)]
        public int Value { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }
    }
}