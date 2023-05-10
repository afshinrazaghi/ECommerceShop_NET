using AutoMapper;
using ECommerceShop.Application.Features.Categories.Requests.Commands;
using ECommerceShop.Application.Features.Categories.Requests.Queries;
using ECommerceShop.Contracts.Models.Category.Requests;
using ECommerceShop.Contracts.Models.Category.Responses;
using ECommerceShop.Domain.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryRequest, GetCategoriesQuery>();

            CreateMap<Category, CategoryResponse>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => src.Id.Value));

            CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryResponse>()
                                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => src.Id.Value));


            CreateMap<UpdateCategoryRequest, UpdateCategoryCommand>();
            CreateMap<Category, UpdateCategoryResponse>()
                                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => src.Id.Value));

            CreateMap<DeleteCategoryRequest, DeleteCategoryCommand>();



        }
    }
}
