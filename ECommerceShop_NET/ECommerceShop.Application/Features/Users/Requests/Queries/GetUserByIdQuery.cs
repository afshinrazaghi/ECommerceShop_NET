using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Requests.Queries
{
    public class GetUserByIdQuery:IRequest<BaseQueryResponse<UserResponse>>
    {
        public Guid UserId { get; set; } = default!;
    }
}
