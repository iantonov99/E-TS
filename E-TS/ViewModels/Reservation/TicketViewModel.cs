using E_TS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.ViewModels.Reservation
{
    public class TicketViewModel
    {
        public bool IsBought { get; set; }

        public string TicketPrice { get; set; }

        public string TicketName { get; set; }
    }
}
