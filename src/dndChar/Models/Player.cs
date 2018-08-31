using System;

namespace dndChar.Models
{
    public class Player
    {
        public Guid PlayerId { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }
    }
}