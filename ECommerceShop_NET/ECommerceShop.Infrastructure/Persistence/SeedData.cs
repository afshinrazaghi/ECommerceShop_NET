using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence
{
    public class SeedData : ISeedData
    {
        private readonly ECommerceShopDbContext _context;

        public SeedData(ECommerceShopDbContext context)
        {
            _context = context;
        }

        public async Task SeedDatabase()
        {
            if (!_context.Users.Any())
            {
                var user = User.Create(Guid.NewGuid(), "admin@admin.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", true);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
