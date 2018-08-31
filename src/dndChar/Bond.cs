using Newtonsoft.Json;

namespace dndChar
{
    public class Bond
    {
        [JsonProperty("item")]
        public string Item { get; set; }
    }
}