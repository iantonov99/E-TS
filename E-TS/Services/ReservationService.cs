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

        public bool DeleteReservation(int Id)
        {
            bool result = false;
            try
            {
                _repo.Delete<Reservation>(Id);
                _repo.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                //TODO ILogger
            }

            return result;
        }

        public List<ReservationsTableViewModel> GetReservations(string UserId)
        {
            var result = _repo.All<Reservation>()
                .Where(r => r.UserId.Equals(UserId) && r.IsBought == true)
                .Select(r => new ReservationsTableViewModel()
                { 
                    Id = r.Id,
                    Address = r.Address,
                    DateAndTime = r.DateAndTime ,
                    IsSpark = r.IsSpark == true ? "Spark" : "Scooter",
                    Price = r.Price
                }).ToList();

            return result;
        }

        public ReservationViewModel GetReservationViewModelById(int Id)
        {
            return _repo.All<Reservation>()
                             .Where(r => r.Id == Id)
                             .Select(r => new ReservationViewModel()
                             {
                                 Id = r.Id,
                                 Address = r.Address,
                                 DateAndTime = r.DateAndTime,
                                 Description = r.Description,
                                 Latitude = r.Latitude,
                                 Longitude = r.Longitude,
                                 Price = r.Price,
                                 SparkOrScooter = r.IsSpark == true ? "Spark" : "Scooter",
                                 UserId = r.UserId
                             }).FirstOrDefault();

        }

        public bool SaveData(ReservationViewModel model)
        {
            bool result = false;
            Reservation entity = null;

            try
            {
                if(model.Id > 0)
                {
                    entity = _repo.GetById<Reservation>(model.Id);
                    entity.IsSpark = model.SparkOrScooter.Equals("Spark");
                    entity.Description = model.Description;
                    entity.DateAndTime = model.DateAndTime;
                    entity.IsDeclined = false;
                    entity.Latitude = model.Latitude;
                    entity.Longitude = model.Longitude;
                    entity.Price = model.Price;
                }
                else
                {
                    entity = new Reservation()
                    {
                        IsSpark = model.SparkOrScooter.Equals("Spark"),
                        Address = model.Address,
                        Description = model.Description,
                        DateAndTime = model.DateAndTime,
                        IsDeclined = false,
                        Latitude = model.Latitude,
                        Longitude = model.Longitude,
                        Price = model.Price,
                        IsBought = false,
                        UserId = model.UserId
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
