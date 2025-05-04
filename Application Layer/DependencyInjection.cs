using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application_Layer.Services;
using Application_Layer.Common.Mappings;

namespace Application_Layer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            var assembly = typeof(DependencyInjection).Assembly;
            assembly = typeof(CustomerProfile).Assembly;
            services.AddAutoMapper(assembly);

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
