using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.DTOs.Users
{
    public interface IUserDto
    {
        public string Email { get; set; }
    }
}
