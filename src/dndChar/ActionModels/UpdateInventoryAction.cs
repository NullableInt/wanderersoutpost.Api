using dndChar.Models.Inventory;

namespace dndChar.ActionModels
{
    public class UpdateInventoryAction : IAction
    {
        public string Type { get; set; }

        public InventoryModel[] Payload { get; set; }

        public string InventoryName { get; set; }
    }
}
