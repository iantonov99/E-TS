using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Имейл")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid.")]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.
        //                    \w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Парола")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Повтори паролата")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Паролите не съвпадат")]
        public string PasswordCheck { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Имена")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Дата на раждане")]
        public DateTime DateOfBirth { get; set; }

    }
}
