namespace dndChar.Character.Utils
{
    public static class AttributeBuilder
    {
        public static Attributes DefaultStats => new Attributes
        {
            Strength = AbilityScoreBuilder.Strength,
            Dexterity = AbilityScoreBuilder.Dexterity,
            Constitution = AbilityScoreBuilder.Constitution,
            Intelligence = AbilityScoreBuilder.Intelligence,
            Wisdom = AbilityScoreBuilder.Wisdom,
            Charisma = AbilityScoreBuilder.Charisma,
        };
    }
}