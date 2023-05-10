using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Categories.Requests.Commands;
using ECommerceShop.Application.Responses;
using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            await _categoryRepository.DeleteCategory(CategoryId.Create(request.Id));
            response.Success = true;
            response.Message = "Category removed successfully!";
            return response;
        }
    }
}
