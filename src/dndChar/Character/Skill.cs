using dndChar.Character.AbilityScores;

namespace dndChar.Character
{
    public class Skill
    {
        public AbilityScore CoreStat { get; set; }

        public ProficiencyBonus Proficiency { get; set; }
    }
}