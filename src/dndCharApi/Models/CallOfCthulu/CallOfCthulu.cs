using System.Collections.Generic;

namespace dndCharApi.Models.CallOfCthulu
{
    public class CallOfCthulu : BaseCharacterSheet
    {
        public InvestigatorProfile Profile { get; set; }
        public Sanity Sanity { get; set; }
        public HitPoints HitPoints { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Weapons> Weapons { get; set; }
        public InvestigatorBackStory BackStory { get; set; }
        public List<GearPossessions> GearPossessions { get; set; }
        public List<CashAssets> CastAssets { get; set; }
        public List <FellowInvestigator> FellowInvestigators { get; set; }

    }
}
