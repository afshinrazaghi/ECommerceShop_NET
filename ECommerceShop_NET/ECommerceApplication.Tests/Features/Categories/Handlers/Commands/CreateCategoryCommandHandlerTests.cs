using ECommerceShop.Application.Features.Categories.Requests.Commands;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.Category.Responses;
using ECommerceShop.Domain.CategoryAggregate;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Tests.Features.Categories.Handlers.Commands
{
    using static Testing;
    public class CreateCategoryCommandHandlerTests:TestBase
    {
        [Test]
        public async Task WhenNameIsEmptyReturnValidationErrorNameIsMandatory()
        {
            var command = new CreateCategoryCommand();
            BaseCommandResponse<CreateCategoryResponse> res = await SendAsync(command);
            res.Message.Should().Be("Name is mandatory");
            res.Success.Should().BeFalse();
        }

        [Test]
        public async Task WhenNameExistsReturnValidationErrorCategoryNameExists()
        {
            await AddAsync(Category.Create("Home & Kitchen", "Home & Kitchen Description"));

            var command = new CreateCategoryCommand()
            {
                Name = "Home & Kitchen"
            };
            BaseCommandResponse<CreateCategoryResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Category with this name already exist!");
        }

        [Test]
        public async Task CreateShouldReturnSuccessWhenNoProblem()
        {
            var command = new CreateCategoryCommand()
            {
                Name = "Home & Kitchen",
                Description = "Home & Kitchen Description"
            };
            BaseCommandResponse<CreateCategoryResponse> res = await SendAsync(command);
            res.Success.Should().BeTrue();
            res.Message.Should().Be("Category created successfully!");
            res.Item!.Name.Should().Be(command.Name);
            res.Item!.Description.Should().Be(command.Description);

        }
    }
}
