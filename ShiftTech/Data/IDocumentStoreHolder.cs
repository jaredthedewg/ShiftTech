using Raven.Client.Documents;

namespace ShiftTech.Data
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }
}
