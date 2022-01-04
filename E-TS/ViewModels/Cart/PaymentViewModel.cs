using System;
using System.ComponentModel.DataAnnotations;

namespace E_TS.ViewModels.Cart
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Номер на картата")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Име на картодържателя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Валидна до")]
        public DateTime ValidTo { get; set; }

        public int IdOfProduct { get; set; }

        public int Table { get; set; }
    }
}
