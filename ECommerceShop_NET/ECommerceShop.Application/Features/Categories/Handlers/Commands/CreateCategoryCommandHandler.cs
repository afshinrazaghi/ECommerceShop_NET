using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Categories.Requests.Commands;
using ECommerceShop.Application.Features.Categories.Validators;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.Category.Responses;
using ECommerceShop.Domain.CategoryAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse<CreateCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CreateCategoryResponse>();
            var category = Category.Create(request.Name, request.Description);
            var validator = new CreateCategoryValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var dbCategory = await _categoryRepository.CreateCategory(category);
                response.Success = true;
                response.Item = _mapper.Map<CreateCategoryResponse>(dbCategory);
                response.Message = "Category created successfully!";
            }
            else
            {
                response.Success = false;
                response.Message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
            }

            return response;


        }
    }
}
