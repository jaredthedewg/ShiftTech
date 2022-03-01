using Raven.Client.Documents;

namespace ShiftTech.Data
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        //initializes the raven document store
        public IDocumentStore Store { get; }
        public DocumentStoreHolder()
        {
            Store = new DocumentStore
            {
                Urls = new[]
                {
                    "http://127.0.0.1:8080/"
                },
                Database = "ShiftTech",
                Conventions = { }
            }.Initialize();
        }
    }

}

