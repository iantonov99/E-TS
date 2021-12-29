using E_TS.Contracts;
using E_TS.Data.Common;
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
    }
}
