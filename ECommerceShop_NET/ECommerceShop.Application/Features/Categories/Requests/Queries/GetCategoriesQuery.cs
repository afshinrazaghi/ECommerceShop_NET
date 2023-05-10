using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.Category.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Requests.Queries
{
    public class GetCategoriesQuery:IRequest<BaseQueryResponse<CategoryResponse>>
    {
        public string? SearchParam { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
