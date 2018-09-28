namespace dndChar.ActionModels
{
    public class UpdateTemporaryHitPointsAction : IAction
    {
        public string Type { get; set; } = "[BASESTATS] update temporary hit points";
        public UpdateTemporaryHitPointsAction(int payload)
        {
            this.Payload = payload;
        }

        public int Payload { get; private set; }
    }
}
