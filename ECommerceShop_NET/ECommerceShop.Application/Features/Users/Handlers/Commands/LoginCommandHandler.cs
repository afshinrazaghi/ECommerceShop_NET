using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Common.Interfaces.Services;
using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Responses;
using ECommerceShop.Domain.UserAggregate.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Handlers.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseCommandResponse<LoginUserResponse>>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
        {
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<LoginUserResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<LoginUserResponse>();
            var user = await _userRepository.GetUser(request.Email);
            if (user != null)
            {
                if (_passwordHasher.VerifyPassword(request.Password, user.Password))
                {
                    var tokenInfo = _jwtTokenGenerator.GenerateToken(user);
                    var refreshToken = Guid.NewGuid().ToString();
                    var refreshTokenExpireDate = tokenInfo.Expiration.AddDays(1);

                    var userToken = UserToken.Create(tokenInfo.AccessToken, tokenInfo.Expiration, refreshToken, refreshTokenExpireDate);
                    user.ClearUserTokens();
                    user.AddUserToken(userToken);

                    await _userRepository.SaveChangesAsync();

                    var userInfo = _mapper.Map<LoginUserResponse>(user);
                    userInfo.AccessToken = tokenInfo.AccessToken;
                    userInfo.RefreshToken = refreshToken;
                    response.Item = userInfo;
                    response.Success = true;
                    response.Message = "User logged in successfully!";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Email or Password is incorrect";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Email or Password is incorrect";
            }

            return response;
        }
    }
}
