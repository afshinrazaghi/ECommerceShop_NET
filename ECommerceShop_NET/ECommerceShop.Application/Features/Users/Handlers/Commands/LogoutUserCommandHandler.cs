using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Application.Responses;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Handlers.Commands
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public LogoutUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseCommandResponse> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            await _userRepository.ClearUserTokens(UserId.Create(request.UserId));
            response.Success = true;
            response.Message = "Logout successfully!";
            return response;
        }
    }
}
