using System;

namespace dndChar.Character
{
    public class ServerState
    {
        public bool Readonly { get; set; }
        
        public Guid AppUserId { get; set; }
    }
}