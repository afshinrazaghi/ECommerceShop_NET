using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Contracts.Models.User.Requests
{
    public class LoginUserRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
