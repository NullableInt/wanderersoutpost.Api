using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dndChar.Data.CompoundTypes
{
    public class CharacterSheet
    {
        private State _state;

        public Guid CharacterSheetId { get; set; }

        [ForeignKey("PlayerId")]
        public Guid OwnerId { get; set; }

        public string AllState
        {
            get => JsonConvert.SerializeObject(_state);
            set => JsonConvert.DeserializeObject<State>(value);
        }
    }
}