using E_TS.Contracts;
using E_TS.Data.Common;
using E_TS.Models;
using E_TS.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IRepository _repo;
        public TicketsService(IRepository repo)
        {
            _repo = repo;
        }

        public bool DeleteTicket(int Id)
        {
            try
            {
                _repo.Delete<Ticket>(Id);
                _repo.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

            return false;
        }

        public List<TicketViewModel> GetTickets()
        {
            var results = _repo.All<Ticket>()
                .Select(r => new TicketViewModel()
                {
                    Id = r.Id,
                    IsBought = r.IsBought,
                    TicketDetails = r.TicketDetail
                }).ToList();

            return results;
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
