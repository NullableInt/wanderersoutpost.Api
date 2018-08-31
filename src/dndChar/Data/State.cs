namespace dndChar.Data
{
    public class State
    {
        public ServerState ServerState { get; set; }
        public CurrencyState CurrencyState { get; set; }
        public InventoryState InventoryState { get; set; }
        public BaseCharacterModelState BaseCharacterModelState { get; set; }
    }
}