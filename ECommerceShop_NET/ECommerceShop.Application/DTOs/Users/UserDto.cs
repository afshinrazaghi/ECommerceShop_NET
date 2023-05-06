using ECommerceShop.Application.DTOs.Addresses;
using ECommerceShop.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.DTOs.Users
{
    public class UserDto : BaseDto, IUserDto
    {
        public string Email { get; set; } = default!;
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public AddressDto ShippingAddress { get; private set; } = default!;
    }
}
