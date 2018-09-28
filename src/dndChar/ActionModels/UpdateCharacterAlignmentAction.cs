using dndChar.Models.BaseStats;

namespace dndChar.ActionModels
{
    public class UpdateCharacterAlignmentAction : IAction
    {
        public string Type { get; set; } = "[BASESTATS] update character alignment";
        public UpdateCharacterAlignmentAction(CharacterAlignment payload)
        {
            Payload = payload;
        }

        public object Payload { get; }
    }
}
