using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_TS.Contracts;
using E_TS.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace E_TS.Controllers
{
    public class ECardController : Controller
    {
        private readonly IECardService eCardService;

        public ECardController(IECardService eCardService)
        {
            this.eCardService = eCardService;
        }
        public IActionResult Index()
        {
            var model = eCardService.GetECardsViewModel();
            model.UserViewModel = new UserViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCard()
        {
            //Save to Db
            return RedirectToAction("Index", "ECard");
        }

        public IActionResult Recharge()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RechargeCard(int Id)
        {
            //Change Row in Db and set isBought to false
            return RedirectToAction("Index", "ECard");
        }

        public IActionResult RechargeTrips()
        {
            return View();
        }
    }
}
