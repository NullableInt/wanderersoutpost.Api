namespace dndCharApi.Models.RpgChar
{
    public class Weapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dmg { get; set; }
        public string Handedness { get; set; }
        public decimal ProficiencyModifier { get; set; }
        public int Price { get; set; }
        public string CurrencyDenomination { get; set; }
        public int Hit { get; set; }
        public int ToHitModifier { get; set; }
        public int Weight { get; set; }
        public string Range { get; set; }
        public string DamageType { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool IsEqupped { get; set; } = false;
        public bool IsAttuned { get; set; } = false;
    }
}
