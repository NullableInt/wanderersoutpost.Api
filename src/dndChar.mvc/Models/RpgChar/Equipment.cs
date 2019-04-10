using System.Collections.Generic;

namespace dndCharApi.Models.RpgChar
{
    public class Equipment
    {
        public List<Weapon> Weapons { get; set; }
        public List<Armor>  Armor { get; set; }
    }
}
