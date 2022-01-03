using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_TS.Controllers
{
    public class ECardController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
