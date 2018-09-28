using dndChar.Models.Currency;

namespace dndChar.ActionModels
{
    public class UpdateTreasureModelAction : IAction
    {
        public string Type { get; set; }

        public TreasureModel Payload { get; set; }

        public int Index { get; set; }
    }
}
