namespace dndChar.ActionModels
{
    public class UpdateDamageTakenAction : IAction
    {
        public string Type { get; set; } = "[BASESTATS] update damage taken";
        public UpdateDamageTakenAction(int payload)
        {
            this.Payload = payload;
        }

        public int Payload { get; private set; }
    }
}
