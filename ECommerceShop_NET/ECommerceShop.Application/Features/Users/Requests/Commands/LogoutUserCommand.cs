using ECommerceShop.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Requests.Commands
{
    public class LogoutUserCommand:IRequest<BaseCommandResponse>
    {
        public Guid UserId { get; set; }
    }
}
