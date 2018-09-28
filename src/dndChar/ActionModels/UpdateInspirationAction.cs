namespace dndChar.ActionModels
{
    public class UpdateInspirationAction : IAction
    {
        public string Type { get; set; } = "[BASESTATS] update inspiration";
        public UpdateInspirationAction(int payload)
        {
            this.Payload = payload;
        }

        public int Payload { get; private set; }
    }
}
