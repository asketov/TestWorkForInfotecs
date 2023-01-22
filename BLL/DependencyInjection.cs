using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Automapper.Profiles;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection
            services)
        {
            services.AddScoped<ValueService>();
            services.AddScoped<ResultService>();
            services.AddScoped<FileService>();
            services.AddAutoMapper(typeof(ValueProfile).Assembly, typeof(ResultProfile).Assembly);
            return services;
        }
    }
}
