using System.Collections.Generic;

using dndChar.Models.Skills;

namespace dndChar.Models.BaseStats
{
    public class BaseCharacterModel
    {
        public BaseStats baseStats;
        public AbilitySavingThrow[] savingThrows;
        public Dictionary<string,SkillModel[]> Skills;
    }
}
