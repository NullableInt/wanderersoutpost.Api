using System.Collections.Generic;

namespace dndCharApi.Models.RpgChar
{
    public class Spells
    {
        public string SpellcastingAbility { get; set; }
        public int SpellSaveDc { get; set; }
        public int SpellAttackBonus { get; set; }
        public int SpellsKnown { get; set; }
        public int CantripsKnown { get; set; }
        public int InvocationsKnown { get; set; }
        public int MaxPrepared { get; set; }
        public List<SpellSlot> SpellSlots { get; set; }
        public List<SpellList> SpellList { get; set; }
        public List<Cantrip> Cantrips { get; set; }
    }
}
