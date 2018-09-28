using dndChar.Models.BaseStats;

namespace dndChar.ActionModels
{
    public class UpdateAbilitySavingThrowAction : IAction
    {
        public string Type { get; set; }

        public AbilitySavingThrow Payload { get; set; }
    }
}
