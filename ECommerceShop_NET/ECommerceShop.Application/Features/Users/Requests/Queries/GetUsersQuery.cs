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
    public class GetUsersQuery:IRequest<BaseQueryResponse<UserResponse>>
    {
        public string? SearchParam { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
