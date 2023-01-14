using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Attributes
{
    public class ValueDateAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate = new DateTime(2000,1,1);
        private readonly DateTime _maxDate = DateTime.Now;

        public ValueDateAttribute()
        {
            ErrorMessage = $"Дата должны быть между {_minDate} и {_maxDate}";
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            var d = (DateTime)value;
            if (d < _minDate || d > _maxDate)
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success!;
        }
    }
}
