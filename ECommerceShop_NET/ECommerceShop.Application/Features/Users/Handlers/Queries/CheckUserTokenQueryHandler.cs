using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Users.Requests.Queries;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Handlers.Queries
{
    public class CheckUserTokenQueryHandler : IRequestHandler<CheckUserTokenQuery, bool>
    {
        private IUserRepository _userRepository;

        public CheckUserTokenQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CheckUserTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(UserId.Create(request.UserId));
            if (user != null)
            {
                return user.UserTokens.Any(ut => ut.AccessToken == request.AccessToken);
            }
            else
            {
                return false;
            }
        }
    }

}
