using ECommerceShop.Application.DTOs.Users;
using ECommerceShop.Application.Responses;
using ECommerceShop.Domain.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Requests.Commands
{
    public record RegisterUserCommand(string Email, string Password) : IRequest<BaseCommandResponse<User>>;
}
