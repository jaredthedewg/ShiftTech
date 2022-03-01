using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using ShiftTech.Data;
using ShiftTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShiftTech.Services
{
    public class CreditCardProviderService : ICreditCardProviderService
    {
        private readonly IDocumentStore _store;

        public CreditCardProviderService(IDocumentStoreHolder documentStoreHolder)
        {
            _store = documentStoreHolder.Store;
        }

        public CreditCardProvider Add(CreditCardProvider provider)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                var existingItem = session.Query<CreditCardProvider>().FirstOrDefault(x => x.Name == provider.Name);

                if (existingItem == null) session.Store(provider);

                session.Advanced.MaxNumberOfRequestsPerSession = 100;

                session.SaveChanges();
            }

            return provider;
        }

        public CreditCardProvider GetProviderById(string id)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                return session.Query<CreditCardProvider>().FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<CreditCardProvider> GetAllProviders()
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                return session.Query<CreditCardProvider>().ToList();
            }
        }

        public bool IsValidProvider(CreditCard card)
        {
            var providers = GetAllProviders();

            foreach (var provider in providers)
            {
                var regex = new Regex($"{provider.RegEx}");
                if (regex.IsMatch(card.CardNumber) && card.CardNumber.Length == provider.Length)
                    return true;
            }

            return false;
        }

        public void DeleteProvider(string id)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                var provider = session.Query<CreditCardProvider>().FirstOrDefault(x => x.Id == id);

                if (provider != null)
                {
                    session.Delete(provider);

                    session.SaveChanges();
                }
            }
        }

    }
}
