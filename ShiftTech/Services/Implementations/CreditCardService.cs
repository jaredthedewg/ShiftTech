using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using ShiftTech.Data;
using ShiftTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftTech.Services 
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IDocumentStore _store;
        private readonly ICreditCardProviderService _creditCardProviderService;

        public CreditCardService(IDocumentStoreHolder documentStoreHolder, ICreditCardProviderService creditCardProviderService)
        {
            _store = documentStoreHolder.Store;
            _creditCardProviderService = creditCardProviderService;
        }

        public string Add(CreditCard card)
        {
            string message = string.Empty;
            using (IDocumentSession session = _store.OpenSession())
            {
                var existingItem = session.Query<CreditCard>().FirstOrDefault(x => x.CardNumber == card.CardNumber);

                if (existingItem == null && _creditCardProviderService.IsValidProvider(card))
                {
                    session.Store(card);
                    session.Advanced.MaxNumberOfRequestsPerSession = 100;

                    session.SaveChanges();

                    message = "Credit Card successfully added";
                }
                else
                {
                    message = "Credit Card already exists in our database or Credit Card Provider is not supported";
                }
            }

            return message;
        }

        public CreditCard GetCardById(string id)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                return session.Query<CreditCard>().FirstOrDefault(x => x.Id == id);
            }
        }

        public CreditCard GetCardByNumber(string cardNumber)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                return session.Query<CreditCard>().FirstOrDefault(x => x.CardNumber == cardNumber);
            }
        }

        public IEnumerable<CreditCard> GetAll()
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                return session.Query<CreditCard>().ToList();
            }
        }

        public void DeleteCreditCard(string id)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                var card = session.Query<CreditCard>().FirstOrDefault(x => x.Id == id);

                if (card != null)
                {
                    session.Delete(card);

                    session.SaveChanges();
                }
            }
        }
    }
}
