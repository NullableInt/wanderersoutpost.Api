﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace dndCharApi.Models.RpgChar
{

    public class RpgCharModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string OwnerID { get; set; }
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
    }
}