using ECommerceShop.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Common.Interfaces.Services
{
    public interface IJwtTokenGenerator
    {
        public (string AccessToken, DateTime Expiration) GenerateToken(User user);

    }
}
