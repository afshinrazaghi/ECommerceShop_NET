using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Requests.Commands
{
    public class LoginCommand : IRequest<BaseCommandResponse<LoginUserResponse>>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
