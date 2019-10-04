using System.Collections.Generic;

namespace TheWanderersOutpost.Api.Models.CallOfCthulu
{
    public class CallOfCthulu : BaseCharacterSheet
    {
        public InvestigatorProfile Profile { get; set; } = new InvestigatorProfile();
        public Characteristics Characteristics { get; set; } = new Characteristics();
        public Sanity Sanity { get; set; } = new Sanity();
        public HitPoints HitPoints { get; set; } = new HitPoints();
        public List<Skills> Skills { get; set; } = new List<Skills>();
        public List<Weapons> Weapons { get; set; } = new List<Weapons>();
        public InvestigatorBackStory BackStory { get; set; } = new InvestigatorBackStory();
        public List<string> GearPossessions { get; set; } = new List<string>();
        public List<CashAssets> CastAssets { get; set; } = new List<CashAssets>();
        public List<FellowInvestigator> FellowInvestigators { get; set; } = new List<FellowInvestigator>();

    }
}
