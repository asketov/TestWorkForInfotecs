using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions.Validate
{
    public class ValidateFileException : Exception
    {
        public ValidateFileException(string message) : base(message)
        {

        }
    }
}
