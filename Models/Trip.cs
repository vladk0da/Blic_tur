using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blic_tur.Models
{
    public class Trip // Поездка
    {
        public int Id { get; set; }
        [Display(Name = "ID водителя")]
        public int DriverId { get; set; }  // Водитель
        [Display(Name = "Водитель")]
        public Driver Driver { get; set; }
        [Display(Name = "ID машины")]
        public int CarId { get; set; } // Машина
        [Display(Name = "Машина")]
        public Car Car { get; set; }
        [Display(Name = "Список заказов")]
        public List<Order> Orders { get; set; } // Список заказов
        [Display(Name = "Дата отправления")]
        public DateTime DateTime { get; set; }
        [Display(Name = "Комментарий")]
        public String Comment { get; set; }

    }
}
