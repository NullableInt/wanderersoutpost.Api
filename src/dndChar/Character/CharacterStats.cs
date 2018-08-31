using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace dndChar.Character
{
    public class CharacterStats
    {
        private string _skills;
        private string _savingThrows;
        private string _attributes;
        private string _health;

        public Guid CharacterStatsId { get; set; }

        [NotMapped]
        public Attributes Health
        {
            get => JsonConvert.DeserializeObject<Attributes>(_health);
            set => _health = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public Attributes Attributes
        {
            get => JsonConvert.DeserializeObject<Attributes>(_attributes);
            set => _attributes = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public IEnumerable<Skill> Skills
        {
            get => JsonConvert.DeserializeObject<IEnumerable<Skill>>(_skills);
            set => _skills = JsonConvert.SerializeObject(value);
        }

        [NotMapped]
        public IEnumerable<SavingThrow> SavingThrows
        {
            get => JsonConvert.DeserializeObject<IEnumerable<SavingThrow>>(_savingThrows);
            set => _savingThrows = JsonConvert.SerializeObject(value);
        }

        public int ProficiencyBonus { get; set; }

        public int Experience { get; set; }

        public string Class { get; set; }

        public int Level { get; set; }

        public string Name { get; set; }

        public string Race { get; set; }

        public string CharacterAlignment { get; set; }

        public int Inspiration { get; set; }

        public int Speed { get; set; }

        public string Background { get; set; }

        public int IniativeBonus { get; set; }
    }
}