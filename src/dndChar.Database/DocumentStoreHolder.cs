using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace dndChar.Database
{
    public class DocumentStoreHolder
    {
        public DocumentStoreHolder(IOptions<MongoConfig> options)
        {
            Store = new MongoClient(System.Environment.GetEnvironmentVariable("MongodbUrl"));
        }


        public IMongoClient Store { get; private set; }
    }
}
