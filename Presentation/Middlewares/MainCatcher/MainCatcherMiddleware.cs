using Common.Exceptions.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Middlewares.MainCatcher
{
    public class MainCatcherMiddleware
    {
        private readonly RequestDelegate _next;

        public MainCatcherMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch
            {
                context.Response.Clear();
                context.Response.StatusCode = 503;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("Service unavailable");
            }
        }
    }
}
