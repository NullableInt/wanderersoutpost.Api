using System.Collections.Generic;

namespace dndChar.mvc.Models.RpgChar
{
    public class Equipment
    {
        public List<Weapon> Weapons { get; set; }
        public List<Armor>  Armor { get; set; }
    }
}
