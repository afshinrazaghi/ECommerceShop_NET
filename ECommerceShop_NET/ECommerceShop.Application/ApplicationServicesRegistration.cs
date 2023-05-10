using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServicesRegistration).Assembly);
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly));
            return services;
        }   


        
    }
}
