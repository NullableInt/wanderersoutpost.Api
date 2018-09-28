using dndChar.Character.AbilityScores;

namespace dndChar.ActionModels
{
    public class UpdateAbilityScore : IAction
    {
        public string Type { get; set; } = "[ABILITYSCORE] update";
        public readonly object Payload;
        public UpdateAbilityScore(AbilityScore payload)
        {
            Payload = payload;
        }
    }
}
