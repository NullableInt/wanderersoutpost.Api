using System;

namespace dndChar.Models
{
    public class Character
    {
        public Guid CharcterId { get; set; }

        public Guid OwnerId { get; set; }

        public CurrencyState CurrencyState { get; set; }

        public InventoryState InventoryState { get; set; }

        public BaseCharacterModelState BaseCharacterModelState { get; set; }
    }
}