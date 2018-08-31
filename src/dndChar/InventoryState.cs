using Newtonsoft.Json;

namespace dndChar
{
    public class InventoryState
    {
        [JsonProperty("personalityTraits")]
        public Bond[] PersonalityTraits { get; set; }

        [JsonProperty("ideals")]
        public Bond[] Ideals { get; set; }

        [JsonProperty("bonds")]
        public Bond[] Bonds { get; set; }

        [JsonProperty("flaws")]
        public Bond[] Flaws { get; set; }

        [JsonProperty("featuresAndTraits")]
        public Bond[] FeaturesAndTraits { get; set; }

        [JsonProperty("otherProficienciesAndLanguages")]
        public Bond[] OtherProficienciesAndLanguages { get; set; }

        [JsonProperty("equipment")]
        public Bond[] Equipment { get; set; }
    }
}