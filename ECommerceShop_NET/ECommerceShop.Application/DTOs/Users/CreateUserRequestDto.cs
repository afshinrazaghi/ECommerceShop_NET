using ECommerceShop.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.DTOs.Users
{
    public class CreateUserRequestDto : BaseDto, IUserDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
