using System.Collections.Generic;

namespace dndCharApi.Models.CallOfCthulu
{
    public class InvestigatorBackStory
    {
        public List<string> PersonalDescription { get; set; }
        public List<string> Ideology { get; set; }
        public List<string> SignificantPeople { get; set; }
        public List<string> MeaningfulLocations { get; set; }
        public List<string> TreasuredPossessions { get; set; }
        public List<string> Traits { get; set; }
        public List<string> InjuriesScars { get; set; }
        public List<string> PhobiasManias { get; set; }
        public List<string> TomesArtifacts { get; set; }
        public List<string> StrangeEncounters { get; set; }
    }
}