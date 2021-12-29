using E_TS.Contracts;
using E_TS.Data.Common;
using E_TS.Data.Models;
using E_TS.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository _repo;
        public ReservationService(IRepository repo)
        {
            _repo = repo;
        }

        public List<ReservationsTableViewModel> GetReservations()
        {
            var result = _repo.All<Reservation>()
                .Select(r => new ReservationsTableViewModel()
                { 
                    Id = r.Id,
                    Address = "",
                    DateAndTime = r.DateAndTime ,
                    IsActive = r.IsActive == true ? "Да" : "Не",
                    IsSpark = r.IsSpark == true ? "Spark" : "Scooter",
                    Price = r.Price
                }).ToList();

            return result;
        }
    }
}
