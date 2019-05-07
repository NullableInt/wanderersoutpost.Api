using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace dndCharApi.Models.RpgChar
{
    public class RpgCharModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ownerID")]
        public string OwnerID { get; set; }
        [BsonElement("profile")]
        public Profile Profile { get; set; }
        [BsonElement("traits")]
        public List<Trait> Traits { get; set; }
        [BsonElement("items")]
        public List<Item> Items { get; set; }
        [BsonElement("abilityScores")]
        public AbilityScores AbilityScores { get; set; }
        [BsonElement("status")]
        public List<Status> Status { get; set; }
        [BsonElement("hitDice")]
        public List<HitDice> HitDice { get; set; }
        [BsonElement("health")]
        public Health Health { get; set; }
        [BsonElement("savingThrows")]
        public List<SavingThrow> SavingThrows { get; set; }
        [BsonElement("skills")]
        public List<Skill> Skills { get; set; }
        [BsonElement("hitDiceType")]
        public List<HitDiceTypeModel> HitDiceType { get; set; }
        [BsonElement("deathSave")]
        public List<DeathSave> DeathSave { get; set; }
        [BsonElement("treasure")]
        public List<Treasure> Treasure { get; set; }
        [BsonElement("characterAppearance")]
        public List<CharacterAppearance> CharacterAppearance { get; set; }
        [BsonElement("featuresTraits")]
        public List<FeaturesTrait> FeaturesTraits { get; set; }
        [BsonElement("equipment")]
        public Equipment Equipment { get; set; }
        [BsonElement("magicItems")]
        public List<MagicItem> MagicItems { get; set; }
        [BsonElement("notes")]
        public List<Note> Notes { get; set; }
        [BsonElement("spells")]
        public Spells Spells { get; set; }
        [BsonElement("feats")]
        public List<Feat> Feats { get; set; }
        public BsonDateTime _created { get; set; }
        public BsonDateTime _lastUpdated { get; set; }
    }
}
