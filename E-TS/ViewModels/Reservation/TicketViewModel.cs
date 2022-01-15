using E_TS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.ViewModels.Reservation
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public bool IsBought { get; set; }
        public string TicketPrice { get; set; }
        public string TicketName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsExpired { get; set; }
        public string userId { get; set; }
    }
}
