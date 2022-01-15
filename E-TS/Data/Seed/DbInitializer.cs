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

            if (!context.Reservations.Any())
            {
                var reservations = new Reservation[]
                {
                    new Reservation{DateAndTime = DateTime.UtcNow.AddDays(2), Description="", IsDeclined = true, IsSpark = true, Latitude = 25.345345, Longitude = 34.53346, Price= 2.80},
                    new Reservation{DateAndTime = DateTime.UtcNow.AddDays(1), Description="", IsDeclined = false, IsSpark = false, Latitude = 25.345345, Longitude = 34.53346, Price= 5.00},
                    new Reservation{DateAndTime = DateTime.UtcNow.AddDays(2).AddHours(5), Description="", IsDeclined = true, IsSpark = false, Latitude = 25.345345, Longitude = 34.53346, Price= 3.60},
                    new Reservation{DateAndTime = DateTime.UtcNow.AddDays(3), Description="", IsDeclined = false, IsSpark = true, Latitude = 25.345345, Longitude = 34.53346, Price= 5.20},
                };
                context.AddRange(reservations);
                context.SaveChanges();
            }

            if (!context.TransportTypes.Any())
            {
                var types = new TransportType[]
                {
                    new TransportType{Type = "Трамвай"},
                    new TransportType{Type = "Тролей"},
                    new TransportType{Type = "Автобус"},
                    new TransportType{Type = "Метро"}
                };
                context.AddRange(types);
                context.SaveChanges();
            }

            if (!context.TransportLines.Any())
            {
                var lines = new TransportLines[]
                {
                    new TransportLines{Number = 7, TransportTypeId = 1},
                    new TransportLines{Number = 280, TransportTypeId = 3},
                    new TransportLines{Number = 94, TransportTypeId = 3},
                    new TransportLines{Number = 111, TransportTypeId = 3},
                    new TransportLines{Number = 5, TransportTypeId = 1},
                };
                context.AddRange(lines);
                context.SaveChanges();
            }


        }
    }
}
