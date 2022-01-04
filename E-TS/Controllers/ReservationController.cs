using E_TS.Contracts;
using E_TS.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;
using E_TS.Extensions;
using Microsoft.AspNetCore.Identity;
using E_TS.Data.Models;
using System.Threading.Tasks;

namespace E_TS.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReservationController(IReservationService reservationService, UserManager<ApplicationUser> userManager)
        {
            this.reservationService = reservationService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var reservations = reservationService.GetReservations(user.Id);

            return View(reservations);
        }

        public async Task<IActionResult> Add()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var reservation = new ReservationViewModel { UserId = user.Id };

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Add(ReservationViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result = reservationService.SaveData(model);

            this.ShowNotificationOnUI(result);


            return RedirectToAction("Index");
        }

        public IActionResult Copy(int Id)
        {
            var reservation = reservationService.GetReservationViewModelById(Id);

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Copy(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Id = 0;
            var result = reservationService.SaveData(model);

            this.ShowNotificationOnUI(result);


            return RedirectToAction("Index");
        }
    }
}