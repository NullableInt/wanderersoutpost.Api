using Newtonsoft.Json;

namespace dndChar
{
    public class Treasure
    {
        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("worth")]
        public long Worth { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}