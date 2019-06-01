namespace dndCharApi.Models.CallOfCthulu
{
    public class HitPoints
    {
        public int MaxHP { get; set; }
        public bool MajorWound { get; set; } = false;
        public bool Dying { get; set; } = false;
        public bool Unconcious { get; set; } = false;
        public int CurrentHitPoints { get; set; }
    }
}