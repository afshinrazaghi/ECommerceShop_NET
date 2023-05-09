using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Contracts.Models.User.Responses
{
    public class RegisterUserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        
    }
}
