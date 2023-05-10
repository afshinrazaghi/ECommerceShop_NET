using ECommerceShop.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Requests.Commands
{
    public class DeleteCategoryCommand:IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
