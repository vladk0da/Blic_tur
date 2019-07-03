using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blic_tur.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Укажите название")]
        [Display(Name="Название")]
        public String Title { get; set; } // Марка машины

        [Required(ErrorMessage = "Укажите тип (спринтер/вито)")]
        [Display(Name = "Тип машины ")]
        public String TypeCar { get; set; } // Спринтер/вито

        [Required(ErrorMessage = "Укажите номер машины")]
        [Display(Name = "Номер машины")]
        public String Number_of_the_car { get; set; } // Номерной знак

        [Required(ErrorMessage = "Укажите макс кол-во человек")]
        [Display(Name = "Вместительность")]
        public int Capacity { get; set; } // Вместимость в кол-ве людей
        [Display(Name = "Комментарий")]
        public String Comment { get; set; }

    }
}
