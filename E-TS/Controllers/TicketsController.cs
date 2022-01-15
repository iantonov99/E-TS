﻿using E_TS.Contracts;
using E_TS.Data.Models;
using E_TS.ViewModels.Reservation;
using E_TS.ViewModels.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            decimal ticketPrice = decimal.Parse(model.TicketPrice);
            string ticketName = model.TicketName;

            ticketService.createUserTickets(isBought, ticketPrice, ticketName, user.Id);

            var allTickets = ticketService.GetTickets(user.Id);
            return RedirectToAction("Index", allTickets);
        }

        // GET: TicketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
