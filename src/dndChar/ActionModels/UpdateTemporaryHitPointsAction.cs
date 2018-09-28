namespace dndChar.ActionModels
{
    public class UpdateTemporaryHitPointsAction : IAction
    {
        public string Type { get; set; }

        public int Payload { get;  set; }
    }
}
