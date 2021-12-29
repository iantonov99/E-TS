using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Повтори паролата")]
        public string PasswordCheck { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber { get; set; }


    }
}
