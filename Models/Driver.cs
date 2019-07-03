using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Blic_tur.Models
{
    public class Driver
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Имя")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Фамилия")]
        public String SurName { get; set; }

        [Required(ErrorMessage = "Укажите логин")]
        [Display(Name = "Логин")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Укажите телефон")]
        [RegularExpression(@"0\d{9}", ErrorMessage = "Некорректный номер телефона")]
        [Display(Name = "Телефон")]
        public String NumberPhone { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
