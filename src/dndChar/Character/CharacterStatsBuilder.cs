using System;
using dndChar.Character.Utils;

namespace dndChar.Character
{
    public static class CharacterStatsBuilder
    {
        public static CharacterStats DefaultCharacterStats()
        {
            return new CharacterStats
            {
                CharacterStatsId = Guid.NewGuid(),
                Attributes = AttributeBuilder.DefaultStats,
                Health = HealthBuilder.DefaultHealth(),
                ////Skills = SkillBuilder.DefaultSkills,
                SavingThrows = SavingThrowBuilder.DefaultSavingThrows,
                Background = string.Empty,
                CharacterAlignment = string.Empty,
                Race = string.Empty,
                Name = string.Empty,
                Class = "Barbarian",
                Experience = 0,
                Inspiration = 0,
                IniativeBonus = -1,
                Level = 1,
                ProficiencyBonus = 2,
                Speed = 30
            };
        }
    }
}