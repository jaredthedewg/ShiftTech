using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftTech.Models;
using ShiftTech.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftTech.Controllers
{
    [Route("/api/cards")]
    public class CreditCardController : Controller
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [Route("/api/cards/all")]
        // GET: CreditCardController
        public ActionResult Index()
        {
            return Json(_creditCardService.GetAll());
        }

        [Route("/api/cards/get")]
        // GET: CreditCardController/Details/5
        public ActionResult Details(string id)
        {
            return Json(_creditCardService.GetCardById(id));
        }

        [Route("/api/cards/create")]
        [HttpPost]
        public ActionResult Create([FromBody]CreditCard creditCard)
        {
            return Json(_creditCardService.Add(creditCard));
        }

        [Route("/api/cards/delete")]
        [HttpPost]
        public ActionResult Delete([FromBody] string id)
        {
            _creditCardService.DeleteCreditCard(id);
            return Json("Card no longer in database");
        }
    }
}
