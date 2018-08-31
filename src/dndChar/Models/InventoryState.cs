using Newtonsoft.Json;

namespace dndChar.Models
{
    public class InventoryState
    {
        [JsonProperty("personalityTraits")]
        public InventoryModel[] PersonalityTraits { get; set; }

        [JsonProperty("ideals")]
        public InventoryModel[] Ideals { get; set; }

        [JsonProperty("bonds")]
        public InventoryModel[] InventoryModels { get; set; }

        [JsonProperty("flaws")]
        public InventoryModel[] Flaws { get; set; }

        [JsonProperty("featuresAndTraits")]
        public InventoryModel[] FeaturesAndTraits { get; set; }

        [JsonProperty("otherProficienciesAndLanguages")]
        public InventoryModel[] OtherProficienciesAndLanguages { get; set; }

        [JsonProperty("equipment")]
        public InventoryModel[] Equipment { get; set; }
    }
}