using dndChar.Data;

namespace dndChar.ActionModels
{
    public class UpdateBaseStatsModelAction : IAction
    {
        public string Type { get; set; }

        public BaseStats Payload { get; set; }
    }
}
