using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dndChar
{
    public class CharacterSheetDbEntry
    {
        [Key]
        public string CharacterSheetId { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [NotMapped]
        public CharacterSheet CharacterSheet { get; set; }

        [Required]
        [MaxLength(32000)]
        public string CharacterSheetJson
        {
            get => JsonConvert.SerializeObject(CharacterSheet);
            set => JsonConvert.DeserializeObject<CharacterSheet>(value);
        }
    }
}
