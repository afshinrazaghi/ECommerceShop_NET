using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using ECommerceShop.Domain.UserTokenAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.UserTokenAggregate
{
    public class UserToken:AggregateRoot<UserTokenId>
    {
        public UserId UserId { get; set; } = default!;
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
