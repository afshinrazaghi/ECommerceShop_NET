using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.UserAggregate
{
    public class UserData
    {
        public string Email { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public bool IsAdmin { get; set; } 
        public string ShippingAddress { get; set; } = default!;
    }
}
