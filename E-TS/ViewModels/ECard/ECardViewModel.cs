using Microsoft.AspNetCore.Mvc.Rendering;
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

        public int TransportNumberName { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Валидна от")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Валидна до")]
        public DateTime ValidTo { get; set; }

        public string UserId { get; set; }

        public SelectList TransportTypes { get; set; }

        public SelectList TransportLines { get; set; }
    }
}
