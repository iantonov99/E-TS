using System;
using System.ComponentModel.DataAnnotations;

namespace E_TS.ViewModels.Cart
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public DateTime ValidTo { get; set; }
    }
}
