using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheWanderersOutpost.Api.Models.RpgChar
{
    public class Skill
    {
        [BsonRepresentation(BsonType.Int32)]
        public int BonusModifier { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string AbilityScore { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ProficiencyModifier { get; set; }
    }
}
