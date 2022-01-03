using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Data.Models
{
    public class TicketDetails
    {
        [Key]
        public int Id { get; set; }

        public decimal TicketPrice { get; set; }

        public string TicketName { get; set; }
    }
}
