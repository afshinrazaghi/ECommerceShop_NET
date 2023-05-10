using AutoMapper;
using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Users.Requests.Queries;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Requests;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Handlers.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, BaseQueryResponse<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseQueryResponse<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse<UserResponse>();
            var user = await _userRepository.GetUser(UserId.Create(request.UserId));
            if (user != null)
            {
                response.Success = true;
                response.Item = _mapper.Map<UserResponse>(user);
            }
            else
            {
                response.Success = false;
                response.Message = "User not found!";
            }

            return response;
        }
    }
}
