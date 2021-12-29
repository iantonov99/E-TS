using System;
using System.ComponentModel.DataAnnotations;

namespace E_TS.Data.Models
{
    public class ECard
    {
        [Key]
        public int Id { get; set; }

        public bool IsPeriod { get; set; }

        public int? TransportType { get; set; }

        public int? TransportNumber { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public int? Trips { get; set; }

    }
}
