namespace TheWanderersOutpost.Api.Models.RpgChar
{
    public class MagicItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public bool RequiresAttunement { get; set; }
        public bool Attuned { get; set; }
        public int MaxCharges { get; set; }
        public int Charges { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
    }
}
