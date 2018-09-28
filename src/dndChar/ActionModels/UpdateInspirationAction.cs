namespace dndChar.ActionModels
{
    public class UpdateInspirationAction : IAction
    {
        public string Type { get; set; }

        public int Payload { get; set; }
    }
}
