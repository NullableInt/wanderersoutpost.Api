using Newtonsoft.Json;

namespace dndChar.Models
{
    public class Treasure
    {
        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("worth")]
        public int Worth { get; set; }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }
    }
}