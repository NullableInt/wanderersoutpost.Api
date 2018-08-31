using dndChar.Models;
using Newtonsoft.Json;

namespace dndChar.Models
{
    public class BaseStats
    {
        [JsonProperty("strength")]
        public AbilityScore Strength { get; set; }

        [JsonProperty("dexterity")]
        public AbilityScore Dexterity { get; set; }

        [JsonProperty("constitution")]
        public AbilityScore Constitution { get; set; }

        [JsonProperty("intelligence")]
        public AbilityScore Intelligence { get; set; }

        [JsonProperty("wisdom")]
        public AbilityScore Wisdom { get; set; }

        [JsonProperty("charisma")]
        public AbilityScore AbilityScore { get; set; }

        [JsonProperty("experience")]
        public int Experience { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("characterAlignment")]
        public string CharacterAlignment { get; set; }

        [JsonProperty("inspiration")]
        public long Inspiration { get; set; }

        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("maxHitPoints")]
        public int MaxHitPoints { get; set; }

        [JsonProperty("tempHitPoints")]
        public int TempHitPoints { get; set; }

        [JsonProperty("damagedHitPoints")]
        public int DamagedHitPoints { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("_iniativeBonus")]
        public int IniativeBonus { get; set; }

        [JsonProperty("_hitPoints")]
        public int HitPoints { get; set; }
    }
}