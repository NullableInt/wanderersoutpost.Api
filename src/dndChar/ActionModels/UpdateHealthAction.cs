namespace dndChar.ActionModels
{
    public class UpdateHealthAction : IAction
    {
        public string Type { get; set; }

        public UpdateHealthPayload Payload { get; set; }
    }

    public class UpdateHealthPayload
    {
        public int Value { get; set; }

        public bool FullHeal { get; set; }
    }
}
