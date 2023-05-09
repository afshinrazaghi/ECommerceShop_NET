using AutoMapper;
using ECommerceShop.API.Controllers.Common;
using ECommerceShop.Application.DTOs.Users;
using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Contracts.Models.User.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShop.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public UserController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var command = _mapper.Map<RegisterUserCommand>(request);
            var res = await _sender.Send(command);
            return Ok(SuccessfullResult(res));
        }

    }
}
