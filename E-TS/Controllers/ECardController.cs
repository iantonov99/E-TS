using System.Threading.Tasks;
using E_TS.Contracts;
using E_TS.Data.Models;
using E_TS.ViewModels.ECard;
using E_TS.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using E_TS.Extensions;
using System;
using Microsoft.AspNetCore.Authorization;

namespace E_TS.Controllers
{
    [Authorize]
    public class ECardController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IECardService eCardService;
        private readonly IDropDownService dropDownService;

        public ECardController(UserManager<ApplicationUser> userManager, IECardService eCardService, IDropDownService dropDownService)
        {
            this.userManager = userManager;
            this.eCardService = eCardService;
            this.dropDownService = dropDownService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = eCardService.GetECardsViewModel(user.Id);
            model.UserViewModel = new UserViewModel() { Name = user.Name, Age = CalculateAge(user.DateOfBirth) };

            return View(model);
        }

        public async Task<IActionResult> CreateCard()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = new ECardViewModel
            {
                UserId = user.Id,
                TransportTypes = dropDownService.GetTransportTypes(),
                TransportLines = dropDownService.GetTransportLines(),
                Periods = dropDownService.GetPeriods()
            };

            return View("Recharge", model);
        }

        public async Task<IActionResult> Recharge(int Id)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = new ECardViewModel
            {
                Id = Id,
                UserId = user.Id,
                TransportTypes = dropDownService.GetTransportTypes(),
                TransportLines = dropDownService.GetTransportLines(),
                Periods = dropDownService.GetPeriods()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult RechargeCard(ECardViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result = eCardService.SaveData(model);

            this.ShowNotificationOnUI(result);

            return RedirectToAction("Index", "ECard");
        }

        public async Task<IActionResult> CreateTrips()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = new ECardTripsViewModel
            {
                UserId = user.Id,
                TransportTypes = dropDownService.GetTransportTypes(),
                TransportLines = dropDownService.GetTransportLines()
            };

            return View("RechargeTrips", model);
        }

        public async Task<IActionResult> RechargeTrips(int Id)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = new ECardTripsViewModel
            {
                Id = Id,
                UserId = user.Id,
                TransportTypes = dropDownService.GetTransportTypes(),
                TransportLines = dropDownService.GetTransportLines()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult RechargeTrips(ECardTripsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = eCardService.SaveDataTrips(model);

            this.ShowNotificationOnUI(result);

            return RedirectToAction("Index", "ECard");
        }

        public IActionResult GetTransportLinesByTransportType(int? TransportType)
        {
            var model = dropDownService.GetTransportLinesByTransportType(TransportType);

            return new JsonResult(model);
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

    }
}
