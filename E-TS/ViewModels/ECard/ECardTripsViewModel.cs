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

        [Display(Name = "Оставащи пътувания")]
        public int? Trips { get; set; }
    }
}
