using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace dndChar.Database
{
    public class DocumentStoreHolder
    {
        public DocumentStoreHolder(IOptions<MongoConfig> mongoSettings)
        {
            Store = new MongoClient(mongoSettings.Value.Url);
        }


        public IMongoClient Store { get; private set; }
    }
}
