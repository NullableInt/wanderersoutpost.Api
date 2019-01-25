using System;

namespace dndChar.mvc.Models.RpgChar
{
    public class Profile
    {
        public Guid CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterImage { get; set; }
        public string Background { get; set; }
        public string PlayerName { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public string Diety { get; set; }
        public string TypeClass { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public int Level { get; set; }
        public string Exp { get; set; }
    }
}
