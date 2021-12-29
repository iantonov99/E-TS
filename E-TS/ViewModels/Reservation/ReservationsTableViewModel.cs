using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.ViewModels.Reservation
{
    public class ReservationsTableViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string IsSpark { get; set; }

        public DateTime DateAndTime { get; set; }

        public double Price { get; set; }

        public string IsActive { get; set; }
    }
}
