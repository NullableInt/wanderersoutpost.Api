using Newtonsoft.Json;

namespace dndChar
{
    public class BaseCharacterModelState
    {
        [JsonProperty("baseStats")]
        public BaseStats BaseStats { get; set; }

        [JsonProperty("loggedInUser")]
        public string LoggedInUser { get; set; }

        [JsonProperty("savingThrows")]
        public SavingThrow[] SavingThrows { get; set; }

        [JsonProperty("skills")]
        public Skill[] Skills { get; set; }
    }
}