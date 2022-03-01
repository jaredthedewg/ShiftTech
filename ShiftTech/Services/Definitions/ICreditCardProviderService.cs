using System;
using System.Collections.Generic;
using ShiftTech.Models;

namespace ShiftTech.Services
{
    public interface ICreditCardProviderService
    {
        CreditCardProvider Add(CreditCardProvider provider);
        CreditCardProvider GetProviderById(string id);
        IEnumerable<CreditCardProvider> GetAllProviders();
        bool IsValidProvider(CreditCard card);
        void DeleteProvider(string id);
    }
}
