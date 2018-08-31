using System;
using dndChar.Character;
using dndChar.Character.Inventory;

namespace dndChar
{
    public class CharacterSheet
    {
        public Guid CharacterSheetId { get; set; }

        public CurrencyState CurrencyState { get; set; }

        public Inventory Inventory { get; set; }

        public CharacterStats CharacterStats { get; set; }
    }
}