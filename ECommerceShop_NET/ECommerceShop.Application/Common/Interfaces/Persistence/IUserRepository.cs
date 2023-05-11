using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        public Task<User?> GetUser(UserId userId);
        public Task<User> AddUser(User user);
        public Task<User?> GetUser(string email);
        public Task<bool> EmailExist(string email);
        public Task SaveChangesAsync();
        public Task ClearUserTokens(UserId userId);
        public IQueryable<User> GetUsers(string? searchParam);
        public Task<User?> UpdateUser(UserId userId, string firstName, string lastName, string? password);


    }
}
