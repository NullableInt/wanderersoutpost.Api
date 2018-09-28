namespace dndChar.Models.BaseStats
{
    public class BaseStats: AbilityScoreBase, IHealthInfo
    {
        public int Experience;
        public CharacterClass Class;
        public int level;
        public string name;
        public string race;
        public CharacterAlignment characterAlignment;
        public int inspiration;
        public int speed;
        public string background;

        public int MaxHitPoints { get; set; }
        public int tempHitPoints { get; set; }
        public int damagedHitPoints { get; set; }
    }
}
