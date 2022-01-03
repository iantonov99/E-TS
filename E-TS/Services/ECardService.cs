using E_TS.Contracts;
using E_TS.Data.Common;
using E_TS.Data.Models;
using E_TS.ViewModels.ECard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Services
{
    public class ECardService : IECardService
    {
        private readonly IRepository _repo;
        public ECardService(IRepository repo)
        {
            _repo = repo;
        }

        public ECardsViewModel GetECardsViewModel()
        {
            var model = new ECardsViewModel
            {
                ECardViewModel = _repo.All<ECard>()
                             .Select(c => new ECardViewModel()
                             {
                                 Id = c.Id,
                                 TransportNumber = c.TransportNumber,
                                 TransportType = c.TransportType,
                                 ValidFrom = c.ValidFrom,
                                 ValidTo = c.ValidTo
                             })
                             .FirstOrDefault(),
                ECardTripsViewModel = _repo.All<ECardTrips>()
                             .Select(c => new ECardTripsViewModel()
                             {
                                 Id = c.Id,
                                 TransportNumber = c.TransportNumber,
                                 TransportType = c.TransportType,
                                 Trips = c.Trips
                             })
                             .FirstOrDefault()
            };

            return model;
        }
    }
}
