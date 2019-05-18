using MongoDB.Bson;
using System.Collections.Generic;

namespace dndCharApi.Models.RpgChar
{
    public class RpgCharModel : BaseCharacterSheet
    {
        public Profile Profile { get; set; }
        public List<Trait> Traits { get; set; }
        public List<Item> Items { get; set; }
        public AbilityScores AbilityScores { get; set; }
        public List<Status> Status { get; set; }
        public List<HitDice> HitDice { get; set; }
        public Health Health { get; set; }
        public List<SavingThrow> SavingThrows { get; set; }
        public List<Skill> Skills { get; set; }
        public List<HitDiceTypeModel> HitDiceType { get; set; }
        public List<DeathSave> DeathSave { get; set; }
        public List<Treasure> Treasure { get; set; }
        public List<CharacterAppearance> CharacterAppearance { get; set; }
        public List<FeaturesTrait> FeaturesTraits { get; set; }
        public Equipment Equipment { get; set; }
        public List<MagicItem> MagicItems { get; set; }
        public List<Note> Notes { get; set; }
        public Spells Spells { get; set; }
        public List<Feat> Feats { get; set; }
        public BsonDateTime _created { get; set; }
        public BsonDateTime _lastUpdated { get; set; }
    }
}
