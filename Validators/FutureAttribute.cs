using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blic_tur.Validators
{
    public class FutureOrTodayAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Дата не может быть в прошлом";
        }

        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            //alter this as needed. I am doing the date comparison if the value is not null

            if (dateValue.Date < DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;

        }
    }
}
