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
    }
}
