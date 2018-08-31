using System;

namespace dndChar.Character.Inventory
{
    public class Treasure
    {
        public Guid TreasureId { get; set; }

        public string Item { get; set; }

        public int Worth { get; set; }

        public CurrencyName CurrencyName { get; set; }
    }
}