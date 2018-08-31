using Newtonsoft.Json;

namespace dndChar.Models
{
    public class InventoryModel
    {
        [JsonProperty("item")]
        public string Item { get; set; }
    }
}