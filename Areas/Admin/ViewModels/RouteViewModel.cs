using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blic_tur.Areas.Admin
{
    [Authorize]
    public class RouteViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; } // Описание
        [Display(Name = "Цена")]
        [Range(minimum: 0, maximum: 10_000)]
        public int Price { get; set; }
        [Display(Name = "Отправление")]
        [Required]
        public Guid CityFromId { get; set; }
        [Display(Name = "Прибытие")]
        [Required]
        public Guid CityToId { get; set; }
    }
}
