namespace dndChar.ActionModels
{
    public class UpdateHealthAction : IAction
    {
        public string Type { get; set; } = "[BASESTATS] update health";
        public UpdateHealthAction(UpdateHealthPayload payload)
        {
            Payload = payload;
        }

        public UpdateHealthPayload Payload { get; private set; }
    }

    public class UpdateHealthPayload
    {
        public int Value { get; set; }
        public bool FullHeal { get; set; }
    }
}
