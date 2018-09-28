using dndChar.Character.AbilityScores;

namespace dndChar.ActionModels
{
    public class UpdateAbilityScoreAction : IAction
    {
        public string Type { get; set; }

        public AbilityScore Payload { get; set; }
    }
}
