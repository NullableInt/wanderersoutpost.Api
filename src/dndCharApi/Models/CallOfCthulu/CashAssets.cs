using System.Collections.Generic;

namespace dndCharApi.Models.CallOfCthulu
{
    public class CashAssets
    {
        public int SpendingLevel { get; set; }
        public decimal Cash { get; set; }
        public List<Assets> Assets { get; set; }
    }

    public class Assets
    {
        public string Name { get; set; }
        public decimal AssetValue { get; set; }
    }
}