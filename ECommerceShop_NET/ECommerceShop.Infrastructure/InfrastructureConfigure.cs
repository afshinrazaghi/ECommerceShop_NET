using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure
{
    public static class InfrastructureConfigure
    {
        public static IApplicationBuilder InfrastructureConfiguration(this  IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ECommerceShopDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<ISeedData>().SeedDatabase();
            }

            return app;
        }
    }
}
