using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Users.Requests.Queries;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Handlers.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, BaseQueryResponse<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseQueryResponse<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse<UserResponse>();
            var users = _userRepository.GetUsers(request.SearchParam);
            int count = await users.CountAsync();
            var res = await _mapper.ProjectTo<UserResponse>(users.Skip(request.Skip).Take(request.Take)).ToListAsync();
            response.Success = true;
            response.Items = res;
            return response;
        }
    }
}
