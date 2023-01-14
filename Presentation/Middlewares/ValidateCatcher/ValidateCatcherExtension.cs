using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Middlewares.ValidateCatcher
{
    public static class ValidateCatcherExtension
    {
        public static IApplicationBuilder UseValidateCatcher(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidateCatcherMiddleware>();
        }
    }
}
