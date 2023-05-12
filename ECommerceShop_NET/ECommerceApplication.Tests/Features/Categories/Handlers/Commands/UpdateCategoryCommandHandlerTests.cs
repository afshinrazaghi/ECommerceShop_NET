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
    public class UpdateCategoryCommandHandlerTests : TestBase
    {

        [Test]
        public async Task WhenNameIsEmptyReturnValidatorErrorForName()
        {
            var command = new UpdateCategoryCommand();

            BaseCommandResponse<UpdateCategoryResponse> res = await SendAsync(command);

            res.Success.Should().BeFalse();
            res.Message.Should().Be("Name is mandatory");
        }

        [Test]
        public async Task WhenNameExistReturnValidationErrorAlreadyExist()
        {
            await AddAsync(Category.Create("Home & Kitchen", "Home & Kitchen Description"));
            var category = await AddAsync(Category.Create("Beauty & Personal Car", "Home & Kitchen Description"));
            var command = new UpdateCategoryCommand()
            {
                Id = category.Id.Value,
                Name = "Home & Kitchen"
            };
            BaseCommandResponse<UpdateCategoryResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Category with this name already exist!");
        }

        [Test]
        public async Task WhenCategoryIdNotExistReturnFailureResponse()
        {
            var command = new UpdateCategoryCommand()
            {
                Id = Guid.NewGuid(),
                Name = "Beauty & Personal Car"
            };
            BaseCommandResponse<UpdateCategoryResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Category not found!");
        }

        [Test]
        public async Task UpdateCategoryShouldReturnSuccess()
        {
            var category = await AddAsync(Category.Create("Beauty & Personal Car", "Home & Kitchen Description"));
            var command = new UpdateCategoryCommand()
            {
                Id = category.Id.Value,
                Name = "Beauty & Personal Car",
                Description = "Beauty & Personal Car Description"
            };

            BaseCommandResponse<UpdateCategoryResponse> res = await SendAsync(command);

            res.Success.Should().BeTrue();
            res.Message.Should().Be("Category updated successfully");
            res.Item!.Name.Should().Be(command.Name);
            res.Item!.Description.Should().Be(command.Description);
        }
    }
}
