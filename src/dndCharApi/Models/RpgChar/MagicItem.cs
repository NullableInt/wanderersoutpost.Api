namespace dndCharApi.Models.RpgChar
{
    public class MagicItem
    {
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemRarity { get; set; }
        public bool ItemRequiresAttunement { get; set; }
        public bool ItemAttuned { get; set; }
        public int ItemMaxCharges { get; set; }
        public int ItemCharges { get; set; }
        public int ItemWeight { get; set; }
        public string ItemDescription { get; set; }
    }
}
