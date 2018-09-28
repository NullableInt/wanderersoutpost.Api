using dndChar.Models.Inventory;

namespace dndChar.ActionModels
{
    public class UpdateInventoryAction : IAction
    {
        public string Type { get; set; } = "[INVENTORY] update";
        public InventoryModel[] Payload { get; private set; }
        public string InventoryName { get; private set; }

        public UpdateInventoryAction(InventoryModel[] payload, string inventoryName)
        {
            Payload = payload;
            InventoryName = inventoryName;
        }
    }
}
