using MongoDB.Bson;
using System.Collections.Generic;

namespace TheWanderersOutpost.Api.Models.Session
{
    public class Session
    {
        public BsonDateTime Date { get; set; }
        public List<string> Notes { get; set; }
    }
}
