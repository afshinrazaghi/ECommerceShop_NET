using ECommerceShop.Application.Features.Categories.Requests.Commands;
using ECommerceShop.Application.Responses;
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
    public class DeleteCategoryCommandHandlerTests : TestBase
    {
        [Test]
        public async Task WhenCategoryIdNotFoundReturnFailureCategoryNotFound()
        {
            var command = new DeleteCategoryCommand()
            {
                Id = Guid.NewGuid()
            };

            BaseCommandResponse res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Category not found!");
        }

        [Test]
        public async Task CategoryRemovedWhenNoProblem()
        {
            var category = await AddAsync(Category.Create("Home & Kitchen", "Home & Kitchen Description"));

            var command = new DeleteCategoryCommand()
            {
                Id = category.Id.Value
            };

            BaseCommandResponse res = await SendAsync(command);
            var dbCategory =await GetAsync<Category>(category.Id);
            res.Success.Should().BeTrue();
            res.Message.Should().Be("Category removed successfully!");
            dbCategory!.DeleteAt.Should().NotBeNull();

        }
    }
}
