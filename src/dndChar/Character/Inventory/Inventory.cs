using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dndChar.Character.Inventory
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }

        private string _personalityTraits;
        private string _ideals;
        private string _bonds;
        private string _flaws;
        private string _featuresAndTraits;
        private string _otherProficienciesAndLanguages;
        private string _equipment;

        [NotMapped]
        public IEnumerable<string> PersonalityTraits {
            get => JsonConvert.DeserializeObject<IEnumerable<string>>(_personalityTraits);
            set => _personalityTraits = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public IEnumerable<string> Ideals
        {
            get => JsonConvert.DeserializeObject<IEnumerable<string>>(_ideals);
            set => _ideals = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public IEnumerable<string> Bonds
        {
            get => JsonConvert.DeserializeObject<IEnumerable<string>>(_bonds);
            set => _bonds = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public IEnumerable<string> Flaws
        {
            get => JsonConvert.DeserializeObject<IEnumerable<string>>(_flaws);
            set => _flaws = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public IEnumerable<string> FeaturesAndTraits
        {
            get => JsonConvert.DeserializeObject<IEnumerable<string>>(_featuresAndTraits);
            set => _featuresAndTraits = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public IEnumerable<string> OtherProficienciesAndLanguages
        {
            get => JsonConvert.DeserializeObject<IEnumerable<string>>(_otherProficienciesAndLanguages);
            set => _otherProficienciesAndLanguages = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public IEnumerable<string> Equipment
        {
            get => JsonConvert.DeserializeObject<IEnumerable<string>>(_equipment);
            set => _equipment = JsonConvert.SerializeObject(value);
        }
    }
}