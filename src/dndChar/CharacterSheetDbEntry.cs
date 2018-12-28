using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dndChar
{
    public class CharacterSheetDbEntry
    {
        public string CharacterSheetId { get; set; }

        public string OwnerId { get; set; }

        public CharacterSheet CharacterSheet { get; set; }

        public string CharacterSheetJson
        {
            get => JsonConvert.SerializeObject(CharacterSheet);
            set => JsonConvert.DeserializeObject<CharacterSheet>(value);
        }
    }
}
