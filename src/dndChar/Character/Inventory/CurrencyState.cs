using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dndChar.Character.Inventory
{
    public class CurrencyState
    {
        public Guid CurrencyStateId { get; set; }

        private string _treasure;

        [NotMapped]
        public IEnumerable<Treasure> Treasure
        {
            get => JsonConvert.DeserializeObject<IEnumerable<Treasure>>(_treasure);
            set => _treasure = JsonConvert.SerializeObject(value);
        }

        public int Copper { get; set; }

        public int Silver { get; set; }

        public int Electrum { get; set; }

        public int Gold { get; set; }

        public int Platinum { get; set; }
    }
}