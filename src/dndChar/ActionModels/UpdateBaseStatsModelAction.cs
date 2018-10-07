using dndChar.Models.BaseStats;

namespace dndChar.ActionModels
{
    public class UpdateBaseStatsModelAction : IAction
    {
        public string Type { get; set; }

        public AbilityScoreBase Payload { get; set; }
    }
}
