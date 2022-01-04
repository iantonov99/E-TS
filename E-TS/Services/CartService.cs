using E_TS.Contracts;
using E_TS.Data.Common;
using E_TS.Data.Models;
using E_TS.Models;
using E_TS.ViewModels.Cart;
using System.Collections.Generic;
using System.Linq;
using E_TS.Constants;
using System;

namespace E_TS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository _repo;
        public CartService(IRepository repo)
        {
            _repo = repo;
        }

        public bool Buy(int Id, int Table, string UserId)
        {
            bool result = false;

            try
            {
                if (Table == Constants.Constants.TicketTable)
                {
                    var entity = _repo.GetById<Ticket>(Id);
                    entity.IsBought = true;
                    entity.StartDate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                    entity.EndDate = DateToByTicketType(DateTime.UtcNow, entity.TicketDetail.TicketName);
                    _repo.Update(entity);
                }
                else if (Table == Constants.Constants.ECardTable)
                {
                    var entity = _repo.GetById<ECard>(Id);
                    entity.IsBought = true;
                    _repo.Update(entity);
                }
                else if (Table == Constants.Constants.ECardTripsTable)
                {
                    var entity = _repo.GetById<ECardTrips>(Id);
                    entity.IsBought = true;
                    _repo.Update(entity);
                }
                else if (Table == Constants.Constants.ReservationTable)
                {
                    var entity = _repo.GetById<Reservation>(Id);
                    entity.IsBought = true;
                    _repo.Update(entity);
                }
                else
                {
                    return result;
                }

                _repo.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                //TODO LOG
            }
            return result;
        }

        public bool BuyAll(string UserId)
        {
            bool result = false;
            try
            {
                var tickets = _repo.All<Ticket>()
                               .Where(t => t.IsBought == false && t.IsDeclined == false);
                var eCards = _repo.All<ECard>()
                       .Where(c => c.IsBought == false && c.IsDeclined == false);
                var eCardTrips = _repo.All<ECardTrips>()
                       .Where(c => c.IsBought == false && c.IsDeclined == false);
                var reservations = _repo.All<Reservation>()
                       .Where(r => r.IsBought == false && r.IsDeclined == false);

                foreach (var i in tickets)
                {
                    i.IsBought = true;
                    i.StartDate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                    i.EndDate = DateToByTicketType(DateTime.UtcNow, i.TicketDetail.TicketName);
                }
                foreach (var i in eCards)
                {
                    i.IsBought = true;
                }
                foreach (var i in eCardTrips)
                {
                    i.IsBought = true;
                }
                foreach (var i in reservations)
                {
                    i.IsBought = true;
                }
                _repo.UpdateRange(tickets);
                _repo.UpdateRange(eCards);
                _repo.UpdateRange(eCardTrips);
                _repo.UpdateRange(reservations);

                _repo.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<CartViewModel> GetCartViewModels(string UserId)
        {
            var list = new List<CartViewModel>();
            var tickets = _repo.All<Ticket>()
                               .Where(t => t.UserId.Equals(UserId) && t.IsBought == false && t.IsDeclined == false)
                               .Select(t => new CartViewModel()
                               {
                                   Id = t.Id,
                                   Product = "Билет",
                                   Table = Constants.Constants.TicketTable,
                                   Price = t.TicketDetail == null ? 0.0 : (double)t.TicketDetail.TicketPrice,
                                   Detail = t.TicketDetail == null ? "" : t.TicketDetail.TicketName
                               })
                               .ToList();
            var eCards = _repo.All<ECard>()
                   .Where(c => c.UserId.Equals(UserId) && c.IsBought == false && c.IsDeclined == false)
                   .Select(c => new CartViewModel()
                   {
                       Id = c.Id,
                       Product = "Карта за период",
                       Table = Constants.Constants.ECardTable,
                       Price = c.Price,
                       Detail = "От: " + c.ValidFrom.ToString("dd MMMM yyyy") + ", до: " + c.ValidTo.ToString("dd MMMM yyyy")
                   })
                   .ToList();
            var eCardTrips = _repo.All<ECardTrips>()
                   .Where(c => c.UserId.Equals(UserId) && c.IsBought == false && c.IsDeclined == false)
                   .Select(c => new CartViewModel()
                   {
                       Id = c.Id,
                       Product = "Карта за пътувания",
                       Table = Constants.Constants.ECardTripsTable,
                       Price = c.Price,
                       Detail = "Пътувания: " + c.Trips
                   })
                   .ToList();
            var reservations = _repo.All<Reservation>()
                   .Where(r => r.UserId.Equals(UserId) && r.IsBought == false && r.IsDeclined == false)
                   .Select(r => new CartViewModel()
                   {
                       Id = r.Id,
                       Product = "Резервация",
                       Table = Constants.Constants.ReservationTable,
                       Price = r.Price,
                       Detail = r.IsSpark == true ? "Spark" : "Scooter"
                   })
                   .ToList();

            list.AddRange(tickets);
            list.AddRange(eCards);
            list.AddRange(eCardTrips);
            list.AddRange(reservations);

            return list;
        }

        public bool Remove(int Id, int Table)
        {
            bool result = false;

            try
            {
                if (Table == Constants.Constants.TicketTable)
                {
                    var entity = _repo.GetById<Ticket>(Id);
                    entity.IsDeclined = true;
                    _repo.Update(entity);
                }
                else if (Table == Constants.Constants.ECardTable)
                {
                    var entity = _repo.GetById<ECard>(Id);
                    entity.IsDeclined = true;
                    _repo.Update(entity);
                }
                else if (Table == Constants.Constants.ECardTripsTable)
                {
                    var entity = _repo.GetById<ECardTrips>(Id);
                    entity.IsDeclined = true;
                    _repo.Update(entity);
                }
                else if (Table == Constants.Constants.ReservationTable)
                {
                    var entity = _repo.GetById<Reservation>(Id);
                    entity.IsDeclined = true;
                    _repo.Update(entity);
                }
                else
                {
                    return result;
                }

                _repo.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                //TODO LOG
            }
            return result;
        }

        private string DateToByTicketType(DateTime startDateTime, string TicketName)
        {
            DateTime resultDateTime = DateTime.Now;
            if (TicketName == "WeekTicket")
            {
                resultDateTime = startDateTime.AddDays(7);
            }
            else if (TicketName == "ThreeDaysTicket")
            {
                resultDateTime = startDateTime.AddDays(3);
            }
            else if (TicketName == "DailyTicket")
            {
                resultDateTime = startDateTime.AddDays(2);
            }
            else
            {
                resultDateTime = startDateTime.AddHours(1);
            }
            return resultDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
