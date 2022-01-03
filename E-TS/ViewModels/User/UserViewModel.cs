using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.ViewModels.User
{
    public class UserViewModel
    {
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Години")]
        public int Age { get; set; }
    }
}
