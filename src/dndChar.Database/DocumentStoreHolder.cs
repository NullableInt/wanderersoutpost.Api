using Microsoft.Extensions.Options;

using Raven.Client.Documents;

namespace dndChar.Database
{
    public class DocumentStoreHolder
    {
        public DocumentStoreHolder(IOptions<RavenConfig> ravenSettings)
        {
            var _ravenSettings = ravenSettings.Value;

            Store = new DocumentStore
            {
                Database = _ravenSettings.DefaultDatabase,
                Urls = new []{_ravenSettings.Url}
            }.Initialize();

        }


        public IDocumentStore Store { get; private set; }
    }
}
