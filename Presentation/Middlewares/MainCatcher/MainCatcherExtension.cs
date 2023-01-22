using Presentation.Middlewares.ValidateCatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Middlewares.MainCatcher
{
    public static class MainCatcherExtension
    {
        public static IApplicationBuilder UseMainCatcher(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MainCatcherMiddleware>();
        }
    }
}
