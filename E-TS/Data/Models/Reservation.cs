using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TS.Data.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public bool IsSpark { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsDeclined { get; set; }

        public bool IsBought { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
