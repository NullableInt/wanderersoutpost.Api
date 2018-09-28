namespace dndChar.Models.BaseStats
{
    public class AbilitySavingThrow
    {
        public AbilityScore ability { get; set; }
        public int Proficency { get; set; }
        public SkillProficiencyBonus ProficiencyBonus { get; set; }
        public int ProficiencyScore { get; set; }
    }
}
