namespace dndChar.Data
{
    public class BaseStats
    {
        public Strength strength { get; set; }
        public Dexterity dexterity { get; set; }
        public Constitution constitution { get; set; }
        public Intelligence intelligence { get; set; }
        public Wisdom wisdom { get; set; }
        public Charisma charisma { get; set; }
        public int experience { get; set; }
        public string @class { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public string race { get; set; }
        public string characterAlignment { get; set; }
        public int inspiration { get; set; }
        public int speed { get; set; }
        public int maxHitPoints { get; set; }
        public int tempHitPoints { get; set; }
        public int damagedHitPoints { get; set; }
        public string background { get; set; }
        public int _iniativeBonus { get; set; }
        public int _hitPoints { get; set; }
    }
}