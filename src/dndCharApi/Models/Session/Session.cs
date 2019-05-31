using MongoDB.Bson;
using System.Collections.Generic;

namespace dndCharApi.Models.Session
{
    public class Session
    {
        public BsonDateTime Date { get; set; }
        public List<string> Sessions { get; set; }
    }
}
