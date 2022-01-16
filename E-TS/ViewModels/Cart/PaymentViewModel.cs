using System;
using System.ComponentModel.DataAnnotations;

namespace E_TS.ViewModels.Cart
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [MinLength(16, ErrorMessage = "Полето изисква точно 16 цифри")]
        [MaxLength(16, ErrorMessage = "Полето изисква точно 16 цифри")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Въведете само цифри")]
        [Display(Name = "Номер на картата")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [MinLength(3, ErrorMessage = "Полето изисква точно 3 цифри")]
        [MaxLength(3, ErrorMessage = "Полето изисква точно 3 цифри")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Въведете само цифри")]
        [Display(Name = "CVV")]
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
