using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E_TS.ViewModels.ECard
{
    public class ECardTripsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Превозно средство")]
        public int? TransportType { get; set; }

        [Display(Name = "Линия")]
        public int? TransportNumber { get; set; }

        public int TransportNumberName { get; set; }

        [Display(Name = "Оставащи пътувания")]
        public int Trips { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        public string UserId { get; set; }

        public SelectList TransportTypes { get; set; }

        public SelectList TransportLines { get; set; }
    }
}
