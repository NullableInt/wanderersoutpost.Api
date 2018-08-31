using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace dndChar
{
    public class Player
    {
        public Guid PlayerId { get; set; }

        [ForeignKey("fk_characterSheet")]
        public CharacterSheet CharacterSheet { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }
    }
}