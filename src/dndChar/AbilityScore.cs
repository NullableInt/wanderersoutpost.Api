using Newtonsoft.Json;

namespace dndChar
{
    public class AbilityScore
    {
        [JsonProperty("name")]
        public AbilityScoreNameEnum AbilityScoreNameEnum { get; set; }

        [JsonProperty("_coreStat")]
        public int CoreStat { get; set; }

        [JsonProperty("_statBonus")]
        public int StatBonus { get; set; }
    }
}