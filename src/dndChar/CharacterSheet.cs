using dndChar.Models.BaseStats;
using dndChar.Models.Currency;
using dndChar.Models.Inventory;
using dndChar.Models.ServerState;

namespace dndChar
{
    public class CharacterSheet
    {
        public ServerStateModel ServerState { get; set; }

        public CurrencyStateModel CurrencyState { get; set; }

        public InventoryStateModel InventoryState { get; set; }

        public BaseCharacterModel BaseCharacterModelState { get; set; }
    }
}
