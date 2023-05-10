using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Common.Interfaces.Services;
using ECommerceShop.Application.DTOs.Users;
using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Application.Features.Users.Validators;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Responses;
using ECommerceShop.Domain.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Handlers.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseCommandResponse<RegisterUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<RegisterUserResponse>();
            var validator = new RegisterUserValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var user = User.Create(request.Email, _passwordHasher.HashPassword(request.Password));
                var newUser = await _userRepository.AddUser(user);

                response.Success = true;
                response.Message = "User Registered Successfully!";
                response.Item = _mapper.Map<RegisterUserResponse>(newUser);
            }
            else
            {
                response.Success = false;
                response.Message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            }

            return response;
        }
    }
}
