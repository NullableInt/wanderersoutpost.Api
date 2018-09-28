using dndChar.Models.Skills;

namespace dndChar.ActionModels
{
    public class UpdateSkillModelAction : IAction
    {
        public string Type { get; set; } = "[SKILLS] update";
        public SkillModel Payload { get; private set; }

        public UpdateSkillModelAction(SkillModel payload)
        {
            Payload = payload;
        }
    }
}
