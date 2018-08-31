using System.Collections.Generic;

namespace dndChar.Data
{
    public class InventoryState
    {
        public List<PersonalityTrait> personalityTraits { get; set; }
        public List<Ideal> ideals { get; set; }
        public List<Bond> bonds { get; set; }
        public List<Flaw> flaws { get; set; }
        public List<FeaturesAndTrait> featuresAndTraits { get; set; }
        public List<OtherProficienciesAndLanguage> otherProficienciesAndLanguages { get; set; }
        public List<Equipment> equipment { get; set; }
    }
}