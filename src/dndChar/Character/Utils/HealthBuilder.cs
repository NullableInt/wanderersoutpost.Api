namespace dndChar.Character.Utils
{
    public static class HealthBuilder
    {
        public static Health DefaultHealth() => new Health
        {
            DamagedHitPoints = 0,
            HitPoints = 10,
            MaxHitPoints = 10,
            TempHitPoints = 0
        };
    }
}