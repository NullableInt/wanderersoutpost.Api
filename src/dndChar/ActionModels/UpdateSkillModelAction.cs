namespace dndChar.ActionModels
{
    public class UpdateSkillModelAction : IAction
    {
        public string Type { get; set; }

        public SkillModelUpdate Payload { get; set; }
    }
}
