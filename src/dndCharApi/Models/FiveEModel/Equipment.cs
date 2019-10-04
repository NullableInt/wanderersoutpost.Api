using System.Collections.Generic;

namespace TheWanderersOutpost.Api.Models.RpgChar
{
    public class Equipment
    {
        public List<Weapon> Weapons { get; set; }
        public List<Armor>  Armor { get; set; }
    }
}
