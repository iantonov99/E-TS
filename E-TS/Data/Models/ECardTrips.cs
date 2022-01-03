using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Data.Models
{
    public class ECardTrips
    {
        [Key]
        public int Id { get; set; }

        public int? TransportType { get; set; }

        public int? TransportNumber { get; set; }

        public int? Trips { get; set; }

        public bool IsBought { get; set; }

        public bool IsDeclined { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
