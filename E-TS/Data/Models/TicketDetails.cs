﻿using System.ComponentModel.DataAnnotations;

namespace E_TS.Data.Models
{
    public class TicketDetails
    {
        [Key]
        public int Id { get; set; }

        public decimal TicketPrice { get; set; }

        public string TicketName { get; set; }
    }
}
