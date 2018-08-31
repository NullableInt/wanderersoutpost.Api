using dndChar.Models;
using Newtonsoft.Json;

namespace dndChar.Models
{
    public class Skill
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coreStat")]
        public AbilityScore CoreStat { get; set; }

        [JsonProperty("_proficiencyScore")]
        public long ProficiencyScore { get; set; }

        [JsonProperty("proficiencyBonus")]
        public string ProficiencyBonus { get; set; }

        [JsonProperty("SkillProficiencyBonus")]
        public string SkillProficiencyBonus { get; set; }
    }
}