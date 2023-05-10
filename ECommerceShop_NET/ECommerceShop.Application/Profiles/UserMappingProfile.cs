using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Services;
using ECommerceShop.Application.DTOs.Users;
using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Contracts.Models.User.Requests;
using ECommerceShop.Contracts.Models.User.Responses;
using ECommerceShop.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserRequest, RegisterUserCommand>();

            CreateMap<User, RegisterUserResponse>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => src.Id.Value));

            CreateMap<LoginUserRequest, LoginCommand>();
            CreateMap<User, LoginUserResponse>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => src.Id.Value));

        }
    }
}
