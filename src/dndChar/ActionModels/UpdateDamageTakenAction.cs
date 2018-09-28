namespace dndChar.ActionModels
{
    public class UpdateDamageTakenAction : IAction
    {
        public string Type { get; set; }

        public int Payload { get; set; }
    }
}
