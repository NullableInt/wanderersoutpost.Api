namespace dndCharApi.Models.RpgChar
{
    public class SpellList
    {
        public string Name { get; set; }
        public bool Prepared { get; set; }
        public bool AlwaysPrepared { get; set; }
        public string Type { get; set; }
        public string SaveAttr { get; set; }
        public string Dmg { get; set; }
        public string DmgType { get; set; }
        public string School { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string MaterialComponents { get; set; }
        public bool isRitual { get; set; }
    }
}
