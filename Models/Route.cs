using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blic_tur.Models
{
    public class Route // Маршрут город-город
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Укажите описание")]
        [Display(Name ="Описание")]
        public string Description { get; set; } // Описание

        [Required(ErrorMessage = "Укажите цену")]
        [Display(Name ="Цена")]
        [Range(minimum:0, maximum:10_000)]
        public int Price { get; set; }

        [Required(ErrorMessage = "Добавьте картинку")]
        [Display(Name ="Картинка")]
        public string Img { get; set; }

        [Required(ErrorMessage = "Укажите город отправления")]
        [Display(Name ="Отправление")]
        public virtual City CityFrom { get; set; }
        public Guid CityFromId { get; set; }

        [Required(ErrorMessage = "Укажите город прибытия")]
        [Display(Name ="Прибытие")]
        public virtual City CityTo { get; set; }
        public Guid CityToId { get; set; }

    }
}
