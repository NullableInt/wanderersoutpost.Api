using System.Collections.Generic;

namespace dndChar.Data
{
    public class CurrencyState
    {
        public List<Treasure> treasure { get; set; }
        public int copper { get; set; }
        public int silver { get; set; }
        public int electrum { get; set; }
        public int gold { get; set; }
        public int platinum { get; set; }
        public Totals totals { get; set; }
    }
}