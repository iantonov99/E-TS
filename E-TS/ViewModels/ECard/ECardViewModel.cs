using System;
using System.ComponentModel.DataAnnotations;

namespace E_TS.ViewModels.ECard
{
    public class ECardViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Превозно средство")]
        public int? TransportType { get; set; }

        [Display(Name = "Линия")]
        public int? TransportNumber { get; set; }

        [Display(Name = "Валидна от")]
        public DateTime ValidFrom { get; set; }

        [Display(Name = "Валидна до")]
        public DateTime ValidTo { get; set; }
    }
}
