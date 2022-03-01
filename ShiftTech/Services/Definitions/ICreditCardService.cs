using System;
using System.Collections.Generic;
using ShiftTech.Models;

namespace ShiftTech.Services
{
    public interface ICreditCardService
    {
        IEnumerable<CreditCard> GetAll();
        string Add(CreditCard card);
        CreditCard GetCardById(string id);
        CreditCard GetCardByNumber(string cardNumber);
        void DeleteCreditCard(string id);
    }
}
