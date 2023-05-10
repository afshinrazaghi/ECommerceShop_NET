using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.Category.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse<CreateCategoryResponse>>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
