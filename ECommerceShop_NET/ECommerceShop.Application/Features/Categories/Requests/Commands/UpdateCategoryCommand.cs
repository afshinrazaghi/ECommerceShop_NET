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
    public class UpdateCategoryCommand:IRequest<BaseCommandResponse<UpdateCategoryResponse>>
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
