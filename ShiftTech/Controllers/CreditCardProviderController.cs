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
    [Route("/api/providers")]
    public class CreditCardProviderController : Controller
    {
        private readonly ICreditCardProviderService _creditCardProviderService;

        public CreditCardProviderController(ICreditCardProviderService creditCardProviderService)
        {
            _creditCardProviderService = creditCardProviderService;
        }

        [Route("/api/providers/all")]
        public ActionResult Index()
        {
            return Json(_creditCardProviderService.GetAllProviders());
        }

        public ActionResult Details(string id)
        {
            return Json(_creditCardProviderService.GetProviderById(id));
        }

        [Route("/api/providers/create")]
        [HttpPost]
        public ActionResult Create([FromBody] CreditCardProvider provider)
        {
            return Json(_creditCardProviderService.Add(provider));
        }

        [Route("/api/providers/delete")]
        [HttpPost]
        public ActionResult Delete([FromBody] string id)
        {
            _creditCardProviderService.DeleteProvider(id);
            return Json("Provider no long in database");
        }

    }
}
