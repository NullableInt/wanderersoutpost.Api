using dndChar.Models.Currency;

namespace dndChar.ActionModels
{
    public class UpdateTreasureModelAction : IAction
    {
        public string Type { get; set; } = "[TREASURE] update treasure model";
        public TreasureModel Payload { get; private set; }
        public int Index { get; private set; }
        public UpdateTreasureModelAction(TreasureModel payload, int index)
        {
            Payload = payload;
            Index = index;
        }
    }
}
