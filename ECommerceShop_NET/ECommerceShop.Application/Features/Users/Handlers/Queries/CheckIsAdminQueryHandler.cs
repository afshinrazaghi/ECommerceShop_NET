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
    public class CheckIsAdminQueryHandler : IRequestHandler<CheckIsAdminQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public CheckIsAdminQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CheckIsAdminQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(UserId.Create(request.UserId));
            if (user != null)
            {
                return user.IsAdmin;
            }
            else
            {
                return false;
            }
        }
    }
}
