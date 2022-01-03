using E_TS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_TS.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<ECard> ECards { get; set; }

        public DbSet<ECardTrips> ECardTrips { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<TransportType> TransportTypes { get; set; }

        public DbSet<TransportLines> TransportLines { get; set; }
    }
}
