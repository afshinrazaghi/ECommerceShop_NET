using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceShopDbContext _context;

        public UserRepository(ECommerceShopDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
