using AutoMapper;
using AutoMapper.QueryableExtensions;
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Categories.Requests.Queries;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.Category.Requests;
using ECommerceShop.Contracts.Models.Category.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Handlers.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, BaseQueryResponse<CategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseQueryResponse<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse<CategoryResponse>();
            var categories = _categoryRepository.GetCategories(request.SearchParam);
            int count = await categories.CountAsync();
            var responseCategories = await _mapper.ProjectTo<CategoryResponse>(categories.Skip(request.Skip).Take(request.Take)).ToListAsync();
            response.Success = true;
            response.Count = count;
            response.Items = responseCategories;
            return response;

        }
    }
}
