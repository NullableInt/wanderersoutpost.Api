using System.Collections.Generic;

namespace dndChar.Character.Utils
{
    public static class SavingThrowBuilder
    {
        public static IEnumerable<SavingThrow> DefaultSavingThrows => new List<SavingThrow>
        {
            new SavingThrow
            {
                Ability = AbilityScoreBuilder.Strength,
                IsProficient = false
            },
            new SavingThrow
            {
                Ability = AbilityScoreBuilder.Dexterity,
                IsProficient = false
            },
            new SavingThrow
            {
                Ability = AbilityScoreBuilder.Constitution,
                IsProficient = false
            },
            new SavingThrow
            {
                Ability = AbilityScoreBuilder.Intelligence,
                IsProficient = false
            },
            new SavingThrow
            {
                Ability = AbilityScoreBuilder.Wisdom,
                IsProficient = false
            },
            new SavingThrow
            {
                Ability = AbilityScoreBuilder.Charisma,
                IsProficient = false
            }
        };
    }
}