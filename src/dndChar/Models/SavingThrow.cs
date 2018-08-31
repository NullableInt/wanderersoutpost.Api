using dndChar.Models;
using Newtonsoft.Json;

namespace dndChar.Models
{
    public class SavingThrow
    {
        [JsonProperty("ability")]
        public AbilityScore Ability { get; set; }

        [JsonProperty("_proficiencyScore")]
        public long ProficiencyScore { get; set; }

        [JsonProperty("proficiencyBonus")]
        public string ProficiencyBonus { get; set; }
    }
}