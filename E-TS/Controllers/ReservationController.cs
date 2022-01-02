using E_TS.Contracts;
using E_TS.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;
using E_TS.Extensions;

namespace E_TS.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var reservations = reservationService.GetReservations();

            return View(reservations);
        }

        public IActionResult Add()
        {
            var reservation = new ReservationViewModel();

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