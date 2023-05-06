using ECommerceShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<ECommerceShopDbContext>(builder =>
            builder.UseSqlServer(config.GetConnectionString("ECommerceConnectionString"));


            return services;
        }
    }
}
