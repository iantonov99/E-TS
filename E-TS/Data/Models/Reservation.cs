using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public bool IsSpark { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsActive { get; set; }
    }
}
