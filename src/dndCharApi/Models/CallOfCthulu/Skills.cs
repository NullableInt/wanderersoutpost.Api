namespace dndCharApi.Models.CallOfCthulu
{
    public class Skills
    {
        public string Name { get; set; }
        public bool Learned { get; set; } = false;
        public int InitialSkillLevel { get; set; } = 1;
        public bool Checked { get; set; } = false;
    }
}