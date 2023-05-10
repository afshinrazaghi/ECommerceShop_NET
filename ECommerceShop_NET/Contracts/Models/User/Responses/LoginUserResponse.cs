using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Contracts.Models.User.Responses
{
    public class LoginUserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ShippingAddress { get; set; }
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;

    }
}
