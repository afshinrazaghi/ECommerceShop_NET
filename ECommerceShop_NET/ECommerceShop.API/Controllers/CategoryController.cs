using AutoMapper;
using ECommerceShop.API.Controllers.Common;
using ECommerceShop.Application.Features.Categories.Requests.Commands;
using ECommerceShop.Application.Features.Categories.Requests.Queries;
using ECommerceShop.Contracts.Models.Category.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShop.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public CategoryController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpGet]
        [Route("getCategories")]
        public async Task<IActionResult> GetCategories([FromQuery] CategoryRequest request)
        {
            var query = _mapper.Map<GetCategoriesQuery>(request);
            var res = await _sender.Send(query);
            return Ok(SuccessfullResult(res));
        }

        [HttpPost]
        [Route("updateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(request);
            var res = await _sender.Send(command);
            return Ok(SuccessfullResult(res));
        }

        [HttpPost]
        [Route("createCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var command = _mapper.Map<CreateCategoryCommand>(request);
            var res = await _sender.Send(command);
            return Ok(SuccessfullResult(res));
        }

        [HttpPost]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryRequest request)
        {
            var command = _mapper.Map<DeleteCategoryCommand>(request);
            var res = await _sender.Send(command);
            return Ok(SuccessfullResult(res));
        }
    }
}
