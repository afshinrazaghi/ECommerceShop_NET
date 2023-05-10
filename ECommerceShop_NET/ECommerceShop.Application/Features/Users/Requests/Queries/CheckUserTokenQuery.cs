using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Requests.Queries
{
    public class CheckUserTokenQuery:IRequest<bool>
    {
        public Guid UserId { get; set; }
        public string AccessToken { get; set; } = default!;
    }
}
