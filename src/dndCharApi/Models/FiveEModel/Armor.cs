namespace TheWanderersOutpost.Api.Models.RpgChar
{
    public class Armor
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int MagicalModifier { get; set; }
        public string CurrencyDenomination { get; set; }
        public int Weight { get; set; }
        public int Class { get; set; }
        public string Stealth { get; set; }
        public string Description { get; set; }
        public bool IsEqupped { get; set; } = false;
        public bool IsAttuned { get; set; } = false;
    }
    }
