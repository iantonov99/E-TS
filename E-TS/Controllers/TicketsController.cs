using E_TS.Contracts;
using E_TS.Data.Models;
using E_TS.ViewModels.Reservation;
using E_TS.ViewModels.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_TS.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ITicketsService ticketService;
        private readonly UserManager<ApplicationUser> userManager;

        public TicketsController(ITicketsService ticketService, UserManager<ApplicationUser> userManager)
        {
            this.ticketService = ticketService;
            this.userManager = userManager;
        }
        // GET: TicketsController
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var allTickets = ticketService.GetTickets(user.Id);
            return View(allTickets);
        }

        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> DeleteTicket([FromBody] TicketIdViewModel model)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            int modelId = model.Id;
           
            ticketService.DeleteTicket(modelId);

            var allTickets = ticketService.GetTickets(user.Id);

            return RedirectToAction("Index", allTickets);
        }

        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> SaveTicket([FromBody] TicketViewModel model)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            bool isBought = model.IsBought;
            double ticketPrice = double.Parse(model.TicketPrice);
            string ticketName = model.TicketName;

            ticketService.createUserTickets(isBought, ticketPrice, ticketName, user.Id);

            var allTickets = ticketService.GetTickets(user.Id);
            return RedirectToAction("Index", allTickets);
        }

    }
}
