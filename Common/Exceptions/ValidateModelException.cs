using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ValidateModelException : Exception
    {
        public readonly List<string> ErrorMessages;
        public ValidateModelException(List<string> errorMessages)
        {
            this.ErrorMessages = errorMessages;
        }
    }
}
