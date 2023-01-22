using Common.Exceptions.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class ValidateHelper
    {
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ValidateModelException"></exception>
        public static void ValidateModel<T>(this T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                throw new ValidateModelException(results.Select(x => x.ErrorMessage).Where(x => x != null).ToList()!);
            }
        }
    }
}
