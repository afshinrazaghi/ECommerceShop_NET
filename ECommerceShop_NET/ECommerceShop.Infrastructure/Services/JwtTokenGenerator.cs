using ECommerceShop.Application.Common.Interfaces.Services;
using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        public JwtTokenGenerator(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }


        public (string AccessToken, DateTime Expiration) GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);
            string displayName = (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName)) ? user.FirstName + " " + user.LastName : user.Email;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName , user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("isAdmin", user.IsAdmin.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, displayName)
            };

            DateTime expiration = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return (accessToken, expiration);
        }
    }
}
