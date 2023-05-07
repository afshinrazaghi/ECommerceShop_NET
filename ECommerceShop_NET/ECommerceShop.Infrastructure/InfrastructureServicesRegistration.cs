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
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Common.Interfaces.Services;
using ECommerceShop.Infrastructure.Services;

namespace ECommerceShop.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<ECommerceShopDbContext>(builder =>
            builder.UseSqlServer(config.GetConnectionString("ECommerceConnectionString")));
            services.AddRepositories();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
