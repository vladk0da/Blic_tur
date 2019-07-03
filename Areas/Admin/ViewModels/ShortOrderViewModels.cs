using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blic_tur.Areas.Admin.ViewModels
{
    [Authorize]
    public class ShortOrderViewModels
    {
        public string RouteId { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}
