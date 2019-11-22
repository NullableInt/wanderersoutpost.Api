using System;

namespace TheWanderersOutpost.Api.DocumentationTesting
{
    public class Operations
    {
        public Uri Href { get; internal set; }
        public string Rel { get; internal set; }
        public string Method { get; internal set; }
        public string ContentType { get; internal set; }
    }
}