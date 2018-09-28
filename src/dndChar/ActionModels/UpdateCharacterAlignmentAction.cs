using dndChar.Models.BaseStats;

namespace dndChar.ActionModels
{
    public class UpdateCharacterAlignmentAction : IAction
    {
        public string Type { get; set; }

        public CharacterAlignment Payload { get; set; }
    }
}
