using E_TS.Models;
using System.Linq;

namespace E_TS.Data.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Tickets.Any())
            {
                return;
            }

            var tickets = new Ticket[]
            {
                new Ticket{Id = 1, Bus = 111},
                new Ticket{Id = 2, Bus = 280},
                new Ticket{Id = 3, Bus = 305},
                new Ticket{Id = 4, Bus = 69}
            };
            context.AddRange(tickets);
            context.SaveChanges();
        }
    }
}
