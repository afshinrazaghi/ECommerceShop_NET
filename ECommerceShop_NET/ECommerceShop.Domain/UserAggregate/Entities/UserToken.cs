using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.UserAggregate.Entities
{
    public class UserToken : Entity<UserTokenId>
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public DateTime CreateAt { get; set; }

        public static UserToken Create(string accessToken, DateTime accessTokenExpireDate, string refreshToken, DateTime refreshTokenExpireDate)
        {
            return new UserToken(accessToken, accessTokenExpireDate, refreshToken, refreshTokenExpireDate);
        }

        private UserToken(string accessToken, DateTime accessTokenExpireDate, string refreshToken, DateTime refreshTokenExpireDate)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            RefreshTokenExpiration = refreshTokenExpireDate;
            AccessTokenExpiration = accessTokenExpireDate;
        }

        private UserToken()
        {

        }

    }
}
