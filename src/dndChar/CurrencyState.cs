using Newtonsoft.Json;

namespace dndChar
{
    public class CurrencyState
    {
        [JsonProperty("treasure")]
        public Treasure[] Treasure { get; set; }

        [JsonProperty("copper")]
        public long Copper { get; set; }

        [JsonProperty("silver")]
        public long Silver { get; set; }

        [JsonProperty("electrum")]
        public long Electrum { get; set; }

        [JsonProperty("gold")]
        public long Gold { get; set; }

        [JsonProperty("platinum")]
        public long Platinum { get; set; }

        [JsonProperty("totals")]
        public Totals Totals { get; set; }
    }
}