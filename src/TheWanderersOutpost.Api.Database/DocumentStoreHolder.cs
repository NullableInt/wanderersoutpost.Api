using MongoDB.Driver;

namespace TheWanderersOutpost.Api.Database
{
  public class DocumentStoreHolder
  {
    public const string CharDatabaseName = "RpgCharModelDb";
    public DocumentStoreHolder()
    {
      Store = new MongoClient(System.Environment.GetEnvironmentVariable("MongodbUrl"));
    }

    public IMongoClient Store { get; private set; }

    public IMongoDatabase GetDefaultDatabase() => Store.GetDatabase(CharDatabaseName);
  }
}
