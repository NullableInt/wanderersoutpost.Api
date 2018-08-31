using Newtonsoft.Json;

namespace dndChar
{
    public class SavingThrow
    {
        [JsonProperty("ability")]
        public AbilityScore Ability { get; set; }

        [JsonProperty("_proficiencyScore")]
        public int ProficiencyScore { get; set; }

        [JsonProperty("proficiencyBonus")]
        public string ProficiencyBonus { get; set; }
    }
}