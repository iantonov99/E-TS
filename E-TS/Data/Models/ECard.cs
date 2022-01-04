using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TS.Data.Models
{
    public class ECard
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TransportType")]
        public virtual int? TransportTypeId { get; set; }

        public virtual TransportType TransportType { get; set; }

        [ForeignKey("TransportLine")]
        public virtual int? TransportNumber { get; set; }

        public virtual TransportLines TransportLine { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public bool IsBought { get; set; }

        public bool IsDeclined { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
