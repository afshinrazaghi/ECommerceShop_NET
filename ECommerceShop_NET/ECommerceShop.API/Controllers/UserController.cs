using AutoMapper;
using ECommerceShop.API.Attributes;
using ECommerceShop.API.Controllers.Common;
using ECommerceShop.Application.DTOs.Users;
using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Application.Features.Users.Requests.Queries;
using ECommerceShop.Contracts.Models.User.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Route("logout")]
        [Authorize]
        [ECommerceShopAuthorize]
        public async Task<ActionResult> Logout(LogoutUserRequest request)
        {
            Guid userId = Guid.Parse(GetTokenInfo()["sub"]);
            var command = new LogoutUserCommand() { UserId = userId };
            var res = await _sender.Send(command);
            return Ok(SuccessfullResult(res));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var command = _mapper.Map<LoginCommand>(request);
            var res = await _sender.Send(command);
            return Ok(SuccessfullMessage(res));
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUserRequest request)
        {
            var query = _mapper.Map<GetUsersQuery>(request);
            var res = await _sender.Send(query);
            return Ok(SuccessfullResult(res));
        }

        [HttpGet]
        [Route("getUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdRequest request)
        {
            var query = _mapper.Map<GetUserByIdQuery>(request);
            var res = await _sender.Send(query);
            return Ok(SuccessfullResult(res));
        }

        [HttpPost]
        [Route("updateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
        {
            var command = _mapper.Map<UpdateUserCommand>(request);
            var res = await _sender.Send(command);
            return Ok(SuccessfullResult(res));
        }

    }
}
