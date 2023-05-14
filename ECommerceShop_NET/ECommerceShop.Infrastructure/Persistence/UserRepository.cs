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

        public async Task<bool> ClearUserTokens(UserId userId)
        {
            var user = await _context.Users.Include(x => x.UserTokens).SingleOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.ClearUserTokens();
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> EmailExist(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            return user != null;
        }

        public async Task<User?> GetUser(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task<User?> GetUser(UserId userId)
        {
            return await _context.Users.Include(x => x.UserTokens).SingleOrDefaultAsync(u => u.Id == userId);
        }

        public IQueryable<User> GetUsers(string? searchParam)
        {
            return _context.Users.Where(u =>
            string.IsNullOrEmpty(searchParam) ||
            (!string.IsNullOrEmpty(u.FirstName) && u.FirstName.Contains(searchParam)) ||
            (!string.IsNullOrEmpty(u.LastName) && u.LastName.Contains(searchParam)) ||
            u.Email.Contains(searchParam)).OrderBy(u => u.CreateAt);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User?> UpdateUser(UserId userId, string firstName, string lastName, string? password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.UpdateUser(firstName, lastName, null, password);
                await _context.SaveChangesAsync();
                return user;
            }
            else
            {
                return null;
            }

        }
    }
}
