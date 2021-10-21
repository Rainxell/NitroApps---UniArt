using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Uniart.DataAccess;

namespace Uniart.Services
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            return services.AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<ICustomerService, CustomerService>();
        }
    }
}
