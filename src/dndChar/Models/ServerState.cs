using Newtonsoft.Json;

namespace dndChar.Models
{
    public class ServerState
    {
        [JsonProperty("readonly")]
        public bool Readonly { get; set; }

        [JsonProperty("appUserId")]
        public string AppUserId { get; set; }
    }
}