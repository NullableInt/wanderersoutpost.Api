namespace dndChar.ActionModels
{
    public class UpdateCharacterLevelAction : IAction
    {
        public string Type { get; set; }

        public int Payload { get; set; }
    }
}
