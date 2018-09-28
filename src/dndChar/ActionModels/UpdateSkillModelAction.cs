using dndChar.Models.Skills;

namespace dndChar.ActionModels
{
    public class UpdateSkillModelAction : IAction
    {
        public string Type { get; set; }

        public SkillModel Payload { get; set; }
    }
}
