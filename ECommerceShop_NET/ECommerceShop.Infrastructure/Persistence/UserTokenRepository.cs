using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Domain.UserTokenAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence
{
    public class UserTokenRepository : IUserTokenRepository
    {
        private readonly ECommerceShopDbContext _context;

        public UserTokenRepository(ECommerceShopDbContext context)
        {
            _context = context;
        }

        public async Task<UserToken> AddToken(UserToken userToken)
        {
            await _context.UserTokens.AddAsync(userToken);
            await _context.SaveChangesAsync();
            return userToken;
        }

    }
}
