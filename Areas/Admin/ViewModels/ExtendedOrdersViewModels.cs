using Blic_tur.Validators;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blic_tur.Areas.Admin.ViewModels
{
    [Authorize]
    public class ExtendedOrdersViewModels
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Укажите как вас зовут")]
        [Display(Name = "Контактное лицо*")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Укажите телефон")]
        [RegularExpression(@"0\d{9}", ErrorMessage = "Некорректный номер телефона")]
        [Display(Name = "Телефон*")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Укажите количество пассажиров")]
        [Display(Name = "Количество*")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Укажите из какого города")]
        [Display(Name="Из какого города*")]
        public string FromCity { get; set; }

        [Display(Name = "Откуда в городе (остановка, адресс)")]
        public string FromPlaceInCity { get; set; }

        [Required(ErrorMessage = "Укажите в какой город")]
        [Display(Name = "В какой город*")]
        public string ToCity { get; set; }

        [Display(Name = "Куда в городе (остановка, адресс)")]
        public string ToPlaceInCity { get; set; }

        [Required(ErrorMessage = "Укажите дату")]
        [Display(Name = "Дата*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [FutureOrToday]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

    }
}
