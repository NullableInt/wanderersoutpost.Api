using dndChar.Character.AbilityScores;

namespace dndChar.ActionModels
{
    public class UpdateAbilityScoreAction : IAction
    {
        public string Type { get; set; } = "[ABILITYSCORE] update";
        public readonly object Payload;
        public UpdateAbilityScoreAction(AbilityScore payload)
        {
            Payload = payload;
        }
    }
}
