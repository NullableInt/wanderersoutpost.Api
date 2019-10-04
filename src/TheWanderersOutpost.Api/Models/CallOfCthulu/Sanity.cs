namespace TheWanderersOutpost.Api.Models.CallOfCthulu
{
    public class Sanity
    {
        public int CurrentSanity { get; set; } = 99;
        public bool TemporaryInsane { get; set; } = false;
        public bool IndefinitelyInsane { get; set; } = false;
        public int StartSanity { get; set; } = 99;
        public int MaxSanity { get; set; } = 100;
    }
}