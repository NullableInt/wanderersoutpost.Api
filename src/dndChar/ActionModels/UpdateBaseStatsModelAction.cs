using dndChar.Data;

namespace dndChar.ActionModels
{
    public class UpdateBaseStatsModelAction : IAction
    {
        public string Type { get; set; } = "[BASESTATS] update";
        public object Payload { get; set; }
        public UpdateBaseStatsModelAction(BaseStats payload)
        {
            Payload = payload;
        }
    }
}
