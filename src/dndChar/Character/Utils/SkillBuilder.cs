using System.Collections.Generic;

namespace dndChar.Character.Utils
{
    public static class SkillBuilder
    {
        public static List<Skill> DefaultSkills => new List<Skill>
        {
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Dexterity,
                Proficiency = ProficiencyBonus.None,
                SkillName = "acrobatics"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Charisma,
                Proficiency = ProficiencyBonus.None,
                SkillName = "animalHandling"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Intelligence,
                Proficiency = ProficiencyBonus.None,
                SkillName = "arcana"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Strength,
                Proficiency = ProficiencyBonus.None,
                SkillName = "athletics"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Charisma,
                Proficiency = ProficiencyBonus.None,
                SkillName = "deception"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Intelligence,
                Proficiency = ProficiencyBonus.None,
                SkillName = "history"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Wisdom,
                Proficiency = ProficiencyBonus.None,
                SkillName = "insight"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Charisma,
                Proficiency = ProficiencyBonus.None,
                SkillName = "intimidation"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Intelligence,
                Proficiency = ProficiencyBonus.None,
                SkillName = "investigation"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Wisdom,
                Proficiency = ProficiencyBonus.None,
                SkillName = "medicine"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Wisdom,
                Proficiency = ProficiencyBonus.None,
                SkillName = "nature"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Wisdom,
                Proficiency = ProficiencyBonus.None,
                SkillName = "perception"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Charisma,
                Proficiency = ProficiencyBonus.None,
                SkillName = "performance"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Charisma,
                Proficiency = ProficiencyBonus.None,
                SkillName = "persuasion"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Wisdom,
                Proficiency = ProficiencyBonus.None,
                SkillName = "religion"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Dexterity,
                Proficiency = ProficiencyBonus.None,
                SkillName = "sleightOfHand"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Dexterity,
                Proficiency = ProficiencyBonus.None,
                SkillName = "stealth"
            },
            new Skill
            {
                CoreStat = AbilityScoreBuilder.Wisdom,
                Proficiency = ProficiencyBonus.None,
                SkillName = "survival"
            }
        };
    }
}