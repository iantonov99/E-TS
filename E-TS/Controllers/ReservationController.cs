using E_TS.Contracts;
using E_TS.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;

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
    }
}