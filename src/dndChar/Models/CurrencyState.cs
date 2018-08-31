using dndChar.Models;
using Newtonsoft.Json;

namespace dndChar.Models
{
    public class CurrencyState
    {
        [JsonProperty("treasure")]
        public Treasure[] Treasure { get; set; }

        [JsonProperty("copper")]
        public int Copper { get; set; }

        [JsonProperty("silver")]
        public int Silver { get; set; }

        [JsonProperty("electrum")]
        public int Electrum { get; set; }

        [JsonProperty("gold")]
        public int Gold { get; set; }

        [JsonProperty("platinum")]
        public int Platinum { get; set; }
    }
}