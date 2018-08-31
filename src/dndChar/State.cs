using Newtonsoft.Json;

namespace dndChar
{
    public class State
    {
        [JsonProperty("ServerState")]
        public ServerState ServerState { get; set; }

        [JsonProperty("CurrencyState")]
        public CurrencyState CurrencyState { get; set; }

        [JsonProperty("InventoryState")]
        public InventoryState InventoryState { get; set; }

        [JsonProperty("BaseCharacterModelState")]
        public BaseCharacterModelState BaseCharacterModelState { get; set; }
    }
}