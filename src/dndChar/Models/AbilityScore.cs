using Newtonsoft.Json;

namespace dndChar.Models
{
    public class AbilityScore
    {
        [JsonProperty("name")]
        public AbilityScoreName AbilityScoreName { get; set; }

        [JsonProperty("_coreStat")]
        public int CoreStat { get; set; }

        [JsonProperty("_statBonus")]
        public int StatBonus { get; set; }
    }
}