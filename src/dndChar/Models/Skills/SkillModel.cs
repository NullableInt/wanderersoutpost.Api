using dndChar.Models.BaseStats;

namespace dndChar.Models.Skills
{
    public class SkillModel
    {
        public Skills name;
        public Character.AbilityScores.AbilityScore coreStat;
        public SkillProficiencyBonus proficiencyBonus;
    }
}
