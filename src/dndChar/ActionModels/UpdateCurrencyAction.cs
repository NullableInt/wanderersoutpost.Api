namespace dndChar.ActionModels
{
    public class UpdateCurrencyAction : IAction
    {
        public string Type { get; set; } = "[TREASURE] update currency";
        public UpdateCurrencyAction(int payload, string currency)
        {
            this.Payload = payload;
            this.Currency = currency;
        }

        public int Payload { get; private set; }
        public string Currency { get; private set; }
    }
}
