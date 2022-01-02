using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        public double Longitude { get; set; }

        [Range(1, 100, ErrorMessage = "Изборът на местоположение е задължителен")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Трябва да изберете едно от двете")]
        public string SparkOrScooter { get; set; }

        public string[] Options = new[] { "Spark", "Scooter" };

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Дата и час")]
        public DateTime DateAndTime { get; set; }

        [Display(Name = "Бележка")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Required(ErrorMessage ="Полето е задължително")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
    }
}
