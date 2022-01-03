using E_TS.Contracts;
using E_TS.Data.Common;
using E_TS.Data.Models;
using E_TS.ViewModels.ECard;
using System;
using System.Linq;

namespace E_TS.Services
{
    public class ECardService : IECardService
    {
        private readonly IRepository _repo;
        public ECardService(IRepository repo)
        {
            _repo = repo;
        }

        public ECardsViewModel GetECardsViewModel(string userId)
        {
            var model = new ECardsViewModel
            {
                ECardViewModel = _repo.All<ECard>()
                             .Where(c => c.UserId.Equals(userId))
                             .Select(c => new ECardViewModel()
                             {
                                 Id = c.Id,
                                 TransportNumber = c.TransportNumber,
                                 TransportType = c.TransportTypeId,
                                 TransportNumberName = c.TransportLine.Number,
                                 ValidFrom = c.ValidFrom,
                                 ValidTo = c.ValidTo
                             })
                             .FirstOrDefault(),
                ECardTripsViewModel = _repo.All<ECardTrips>()
                             .Where(c => c.UserId.Equals(userId))
                             .Select(c => new ECardTripsViewModel()
                             {
                                 Id = c.Id,
                                 TransportNumber = c.TransportNumber,
                                 TransportType = c.TransportTypeId,
                                 TransportNumberName = c.TransportLine.Number,
                                 Trips = c.Trips
                             })
                             .FirstOrDefault()
            };

            return model;
        }

        public bool SaveData(ECardViewModel model)
        {
            bool result = false;
            ECard entity = null;

            try
            {
                if (model.Id > 0)
                {
                    entity = _repo.GetById<ECard>(model.Id);
                    entity.ValidFrom = model.ValidFrom;
                    entity.ValidTo = model.ValidTo;
                    entity.TransportTypeId = model.TransportType;
                    entity.TransportNumber = model.TransportNumber;
                    entity.IsDeclined = false;
                    entity.IsBought = false;
                }
                else
                {
                    entity = new ECard()
                    {
                        IsDeclined = false,
                        TransportNumber = model.TransportNumber,
                        TransportTypeId = model.TransportType,
                        UserId = model.UserId,
                        ValidFrom = model.ValidFrom,
                        ValidTo = model.ValidTo,
                        IsBought = false
                    };
                    _repo.Add(entity);
                }

                _repo.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                //ILogger
            }

            return result;
        }

        public bool SaveDataTrips(ECardTripsViewModel model)
        {
            bool result = false;
            ECardTrips entity = null;

            try
            {
                if (model.Id > 0)
                {
                    entity = _repo.GetById<ECardTrips>(model.Id);
                    entity.Trips = model.Trips;
                    entity.TransportTypeId = model.TransportType;
                    entity.TransportNumber = model.TransportNumber;
                    entity.IsDeclined = false;
                    entity.IsBought = false;
                }
                else
                {
                    entity = new ECardTrips()
                    {
                        IsDeclined = false,
                        TransportNumber = model.TransportNumber,
                        TransportTypeId = model.TransportType,
                        UserId = model.UserId,
                        Trips = model.Trips,
                        IsBought = false
                    };
                    _repo.Add(entity);
                }

                _repo.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                //ILogger
            }

            return result;
        }
    }
}
