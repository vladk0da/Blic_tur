using Blic_tur.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blic_tur.Models
{
    public class Order // Заказ
    {
        public Guid Id { get; set; } // ID заказа

        [Display(Name = "Количество")]
        [Required]
        public int Amount { get; set; }

        [Display(Name = "Телефон")]
        [Required]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Имя")]
        [Required]
        [MaxLength(60)]
        public string Name { get; set; } // Покупатель

        [Display(Name = "ID Маршрута")]
        public Guid RouteId { get; set; } // ID Маршрута Город-Город

        [Display(Name = "Маршрут")]
        public Route Route { get; set; } // Маршрут Город-Город

        [Display(Name = "Дата отправления")]
        [FutureOrToday]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; } // Дата отправления

        [Display(Name = "Место прибытия")]
        public string ToPlaceInCity { get; set; }

        [Display(Name = "Место отправления")]
        public string FromPlaceInCity { get; set; }

        [Display(Name = "Комментарий")]
        [MaxLength(1000)]
        public string Comment { get; set; }
    }
}
