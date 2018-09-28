namespace dndChar.Models.BaseStats
{
    public interface IHealthInfo
    {
        int MaxHitPoints { get; set; }
        int tempHitPoints { get; set; }
        int damagedHitPoints { get; set; }
    }
}
