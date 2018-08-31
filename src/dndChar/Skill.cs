using Newtonsoft.Json;

namespace dndChar
{
    public class Skill
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coreStat")]
        public AbilityScore CoreStat { get; set; }
        
        [JsonProperty("proficiencyBonus")]
        public int ProficiencyBonus { get; set; }

        [JsonProperty("SkillProficiencyBonus")]
        public SkillProficiencyBonus SkillProficiencyBonus { get; set; }
    }
}