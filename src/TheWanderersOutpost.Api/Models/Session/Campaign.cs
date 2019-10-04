using System.Collections.Generic;

namespace TheWanderersOutpost.Api.Models.Session
{
    public class Campaign : BaseCharacterSheet
    {
        public List<string> Characters { get; set; }
        public List<Session> Session { get; set; }
        public string CampaignImage { get; set; }
        public string CampaignType { get; set; }
    }
}
