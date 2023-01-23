using System.ComponentModel.DataAnnotations;

namespace BLL.Attributes
{
    public class ValueDateAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate = new DateTime(2000,1,1);
        private DateTime _maxDate;

        public ValueDateAttribute()
        {
            ErrorMessage = $"Дата должны быть между {_minDate} и текущей";
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            _maxDate = DateTime.Now;
            if (value == null) throw new ArgumentNullException(nameof(value));
            var d = (DateTime)value;
            if (d < _minDate || d > _maxDate)
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success!;
        }
    }
}
