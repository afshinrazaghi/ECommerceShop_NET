using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Requests.Commands
{
    public class UpdateUserCommand : IRequest<BaseCommandResponse<UserResponse>>
    {
        public Guid Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
    }
}
