using System.Collections.Generic;

namespace TheWanderersOutpost.Api
{
    public class AllowedCors
    {
#pragma warning disable CA1819 // Properties should not return arrays
        public string[] Cors { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
    }
}