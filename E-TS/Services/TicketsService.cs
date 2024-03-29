﻿using E_TS.Contracts;
using E_TS.Data.Common;
using E_TS.Data.Models;
using E_TS.Models;
using E_TS.ViewModels.Reservation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IRepository _repo;
        private readonly ILogger<TicketsService> logger;

        public TicketsService(IRepository repo, ILogger<TicketsService> logger)
        {
            _repo = repo;
            this.logger = logger;
        }

        public bool DeleteTicket(int Id)
        {
            try
            {
                _repo.Delete<Ticket>(Id);
                _repo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Debug, $"error occured: {ex.Message}");
            }

            return false;
        }

        public List<TicketViewModel> GetTickets(string userId)
        {
            var results = _repo.All<Ticket>()
                .Where(u => u.UserId == userId)
                .Select(r => new TicketViewModel()
                {
                    Id = r.Id,
                    IsBought = r.IsBought,
                    TicketPrice = r.TicketDetail.TicketPrice.ToString(),
                    TicketName = r.TicketDetail.TicketName,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    IsExpired = r.IsExpired
                }).ToList();

            foreach (var res in results)
            {
                DateTime dateTimeNow = DateTime.Now;
                DateTime endDate = res.EndDate;

                int resId = res.Id;

                Ticket ticket = _repo.All<Ticket>().Where(t => t.Id == resId).FirstOrDefault();

                if(dateTimeNow > endDate)
                {
                    ticket.IsExpired = true;
                    _repo.Update(ticket);
                    _repo.SaveChanges();
                }
            }

            return results;
        }

        private TicketDetails getCorrectTicketDetails(double ticketPrice, string ticketName)
        {
            var ticketDetail = _repo.All<TicketDetails>()
               .Where(i => i.TicketName.Equals(ticketName))
               .FirstOrDefault();

            return ticketDetail;
        }

        public List<TicketViewModel> GetTickets(bool isBought, decimal ticketPrice, string ticketName)
        {
            var results = _repo.All<Ticket>()
                .Select(r => new TicketViewModel()
                {
                    IsBought = isBought,
                    TicketPrice = ticketPrice.ToString(),
                    TicketName = ticketName,
                }).ToList();

            return results;
        }

        private DateTime GetEndDate(DateTime startDateTime, string ticketName)
        {
            DateTime resultDateTime = DateTime.Now;
            if(ticketName == "WeekTicket")
            {
                resultDateTime = startDateTime.AddDays(7);
            }
            else if(ticketName == "ThreeDaysTicket")
            {
                resultDateTime = startDateTime.AddDays(3);
            }
            else if(ticketName == "DailyTicket")
            {
                resultDateTime = startDateTime.AddDays(1);
            }
            else
            {
                resultDateTime = startDateTime.AddHours(1);
            }

            return resultDateTime;
        }

        public bool createUserTickets(bool isBought, double ticketPrice, string ticketName, string userId)
        {
            var ticketDetail = getCorrectTicketDetails(ticketPrice, ticketName);

            try
            {

                DateTime startDate = DateTime.Now;
                var newTicket = new Ticket()
                {
                    IsBought = isBought,
                    StartDate = startDate,
                    EndDate = GetEndDate(startDate, ticketName),
                    TicketDetail = ticketDetail,
                    UserId = userId,
                    IsDeclined = false
                };

                _repo.Add(newTicket);
                _repo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Debug, $"error occured: {ex.Message}");
                return false;
            }
        }

        public TicketViewModel GetTicketViewModelById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool SaveData(TicketViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
