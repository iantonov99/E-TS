﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TS.Data.Models
{
    public class ECard
    {
        [Key]
        public int Id { get; set; }

        public int? TransportType { get; set; }

        public int? TransportNumber { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public bool IsBought { get; set; }

        public bool IsDeclined { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
