using E_TS.Data.Models;
using E_TS.Models;
using System;
using System.Linq;

namespace E_TS.Data.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Tickets.Any())
            {
                var tickets = new Ticket[]
{
                    new Ticket{Bus = 111},
                    new Ticket{Bus = 280},
                    new Ticket{Bus = 305},
                    new Ticket{Bus = 69}
};
                context.AddRange(tickets);
                context.SaveChanges();
            }

            if (!context.Reservations.Any())
            {
                var reservations = new Reservation[]
                {
                    new Reservation{DateAndTime = DateTime.UtcNow.AddDays(2), Description="", IsActive = true, IsSpark = true, Latitude = 25.345345, Longitude = 34.53346, Price= 2.80},
                    new Reservation{DateAndTime = DateTime.UtcNow.AddDays(1), Description="", IsActive = false, IsSpark = false, Latitude = 25.345345, Longitude = 34.53346, Price= 5.00},
                    new Reservation{DateAndTime = DateTime.UtcNow.AddDays(2).AddHours(5), Description="", IsActive = true, IsSpark = false, Latitude = 25.345345, Longitude = 34.53346, Price= 3.60},
                    new Reservation{DateAndTime = DateTime.UtcNow.AddDays(3), Description="", IsActive = false, IsSpark = true, Latitude = 25.345345, Longitude = 34.53346, Price= 5.20},
                };
                context.AddRange(reservations);
                context.SaveChanges();
            }


        }
    }
}
