using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Services;
using ECommerceShop.Application.DTOs.Users;
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
        private readonly IPasswordHasher _passwordHasher;
        public UserMappingProfile(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            CreateMap<CreateUserRequestDto, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => _passwordHasher.HashPassword(src.Password)));
        }
    }
}
