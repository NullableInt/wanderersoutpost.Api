namespace dndChar.ActionModels
{
    public class UpdateCharacterLevelAction : IAction
    {
        public string Type { get; set; } = "[BASESTATS] update character level";
        public UpdateCharacterLevelAction(int payload)
        {
            this.Payload = payload;
        }
        public int Payload { get; private set; }
    }
}
