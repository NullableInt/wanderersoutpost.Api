using dndChar.Character.AbilityScores;

namespace dndChar.Character.Utils
{
    public static class AbilityScoreBuilder
    {
        public static AbilityScore Strength => new AbilityScore { Name = AbilityScoreName.Strength.ToString(), Score = 8};

        public static AbilityScore Dexterity => new AbilityScore { Name = AbilityScoreName.Dexterity.ToString(), Score = 8 };

        public static AbilityScore Constitution => new AbilityScore { Name = AbilityScoreName.Constitution.ToString(), Score = 8 };

        public static AbilityScore Intelligence => new AbilityScore { Name = AbilityScoreName.Intelligence.ToString(), Score = 8 };

        public static AbilityScore Wisdom => new AbilityScore { Name = AbilityScoreName.Wisdom.ToString(), Score = 8 };

        public static AbilityScore Charisma => new AbilityScore { Name = AbilityScoreName.Charisma.ToString(), Score = 8};
    }
}