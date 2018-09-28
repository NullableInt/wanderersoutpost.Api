namespace dndChar.ActionModels
{
    public class UpdateCurrencyAction : IAction
    {
        public string Type { get; set; }

        public int Payload { get; set; }

        public string Currency { get; set; }
    }
}
