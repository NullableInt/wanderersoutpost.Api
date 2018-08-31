using System.Collections.Generic;

namespace dndChar.Data
{
    public class BaseCharacterModelState
    {
        public BaseStats baseStats { get; set; }
        public List<object> savingThrows { get; set; }
        public List<object> skills { get; set; }
    }
}