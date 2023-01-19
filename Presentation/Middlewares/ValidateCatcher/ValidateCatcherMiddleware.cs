using System.ComponentModel.DataAnnotations;
using System.Text;
using Common.Exceptions.Validate;

namespace Presentation.Middlewares.ValidateCatcher
{
    public class ValidateCatcherMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidateCatcherMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidateModelException ex)
            {
                StringBuilder str = new StringBuilder("В одной из моделей есть невалидные поля:\n");
                context.Response.Clear();
                context.Response.StatusCode = 400;
                ex.ErrorMessages.ForEach(x => str.AppendLine(x));
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync(str.ToString());
            }
            catch (ValidateFileException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
