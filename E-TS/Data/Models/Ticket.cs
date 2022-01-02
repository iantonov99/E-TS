using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public int Bus { get; set; }

        public bool IsBought { get; set; }

    }
}
