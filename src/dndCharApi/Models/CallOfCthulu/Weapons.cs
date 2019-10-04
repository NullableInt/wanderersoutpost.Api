namespace TheWanderersOutpost.Api.Models.CallOfCthulu
{
    public class Weapons
    {
        public string Name { get; set; }
        public int RegularCheck { get; set; }
        public int HardCheck { get; set; }
        public int ExtremeCheck { get; set; }
        public string Damage { get; set; }
        public string Range { get; set; }
        public int AttacksPerRound { get; set; } = 1;
        public int Ammo { get; set; } = 0;
        public bool Malfunctioning { get; set; } = false;
    }
}