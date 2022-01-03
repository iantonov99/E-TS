using E_TS.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TS.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public bool IsBought { get; set; }

        public bool IsDeclined { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public TicketDetails TicketDetail { get; set; }
    }
}
