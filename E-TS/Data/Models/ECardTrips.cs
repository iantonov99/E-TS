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

        [ForeignKey("TransportType")]
        public virtual int? TransportTypeId { get; set; }

        public virtual TransportType TransportType { get; set; }

        [ForeignKey("TransportLine")]
        public virtual int? TransportNumber { get; set; }

        public virtual TransportLines TransportLine { get; set; }

        public int Trips { get; set; }

        public bool IsBought { get; set; }

        public bool IsDeclined { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
