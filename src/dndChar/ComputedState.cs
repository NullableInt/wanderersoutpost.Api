using Newtonsoft.Json;

namespace dndChar
{
    public class ComputedState
    {
        [JsonProperty("state")]
        public State State { get; set; }
    }
}