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
                new Ticket{Bus = 111},
                new Ticket{Bus = 280},
                new Ticket{Bus = 305},
                new Ticket{Bus = 69}
            };
            context.AddRange(tickets);
            context.SaveChanges();
        }
    }
}
