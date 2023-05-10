using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Categories.Requests.Commands;
using ECommerceShop.Application.Features.Categories.Validators;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.Category.Responses;
using ECommerceShop.Domain.CategoryAggregate;
using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse<UpdateCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<UpdateCategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UpdateCategoryResponse>();
            var validator = new UpdateCategoryValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var res = await _categoryRepository.UpdateCategory(CategoryId.Create(request.Id), request.Name, request.Description);
                response.Success = true;
                response.Message = "Category updated successfully";
                response.Item = _mapper.Map<UpdateCategoryResponse>(res);
            }
            else
            {
                response.Success = false;
                response.Message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
                response.Message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            }

            return response;
        }
    }
}
