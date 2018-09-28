using dndChar.Models.BaseStats;

namespace dndChar.ActionModels
{
    public class UpdateAbilitySavingThrowAction : IAction
    {
        public string Type { get; set; } = "[BASESTATS] update ability saving throw";
        public readonly object Payload;

        public UpdateAbilitySavingThrowAction(AbilitySavingThrow payload)
        {
            this.Payload = payload;
        }
    }
}
