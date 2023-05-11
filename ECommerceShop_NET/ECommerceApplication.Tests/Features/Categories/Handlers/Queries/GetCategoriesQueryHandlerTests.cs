using ECommerceShop.Application.Features.Categories.Requests.Queries;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.Category.Responses;
using ECommerceShop.Domain.CategoryAggregate;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Tests.Features.Categories.Handlers.Queries
{
    using static Testing;
    public class GetCategoriesQueryHandlerTests: TestBase
    {
        [Test]
        public async Task ShouldReturnAllCategories()
        {
            await AddAsync(Category.Create("Test", "Test Description"));

            var query = new GetCategoriesQuery()
            {
                Skip = 0,
                Take = int.MaxValue
            };

            BaseQueryResponse<CategoryResponse> res = await SendAsync(query);
            res.Success.Should().BeTrue();
            res.Items.Should().HaveCount(1);
            res.Items!.First().Name.Should().Be("Test");
        }
    }
}
