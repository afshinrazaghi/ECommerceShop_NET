using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> EmailExist(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user != null;
        }

        public async Task<User?> GetUser(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public Task<User?> GetUser(UserId userId)
        {
            return _context.Users.Include(x => x.UserTokens).SingleOrDefaultAsync(u => u.Id == userId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
