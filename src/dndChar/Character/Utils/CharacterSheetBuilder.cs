using System;
using System.Collections.Generic;

namespace dndChar.Character.Utils
{
    public static class CharacterSheetBuilder
    {
        public static CharacterSheet DefaultCharacterSheet() => new CharacterSheet
        {
            CharacterSheetId = Guid.NewGuid(),
            CharacterStats = CharacterStatsBuilder.DefaultCharacterStats(),
            Inventory = DefaultInventory()
        };

        private static CharacterStats DefaultCharacterStats()
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

        private static Inventory.Inventory DefaultInventory()
        {
            return new Inventory.Inventory
            {
                InventoryId = Guid.NewGuid(),
                Bonds = new List<string>(),
                Equipment = new List<string>(),
                FeaturesAndTraits = new List<string>(),
                Flaws = new List<string>(),
                Ideals = new List<string>(),
                OtherProficienciesAndLanguages = new List<string>(),
                PersonalityTraits = new List<string>()
            };
        }
    }
}