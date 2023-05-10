using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Common.Interfaces.Services;
using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Application.Features.Users.Validators;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Requests;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<BaseCommandResponse<UserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UserResponse>();
            var validator = new UpdateUserValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                var res = await _userRepository.UpdateUser(UserId.Create(request.Id), request.FirstName, request.LastName, _passwordHasher.HashPassword(request.Password));
                if (res != null)
                {
                    response.Success = true;
                    response.Item = _mapper.Map<UserResponse>(res);
                }
                else
                {
                    response.Success = false;
                    response.Message = "User not found";
                }
            }
            else
            {
                response.Success = false;
                response.Message = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            }
            return response;
        }
    }
}
