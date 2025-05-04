using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application_Layer.Services;

namespace Application_Layer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
