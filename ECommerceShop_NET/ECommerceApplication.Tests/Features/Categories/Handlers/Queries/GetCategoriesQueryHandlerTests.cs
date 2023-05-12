using Bogus;
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
    public class GetCategoriesQueryHandlerTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllCategories()
        {
            await AddAsync(Category.Create("Home & Kitchen", "Home & Kitchen Description"));

            var query = new GetCategoriesQuery()
            {
                Skip = 0,
                Take = int.MaxValue
            };

            BaseQueryResponse<CategoryResponse> res = await SendAsync(query);
            res.Success.Should().BeTrue();
            res.Items.Should().HaveCount(1);
            res.Items!.First().Name.Should().Be("Home & Kitchen");
        }

        [Test]
        public async Task WhenSkipGreaterThanZeroShouldReturnCategoriesAfterSkip()
        {

            //Randomizer.Seed = new Random(8675309);
            var categoryData = FakeDataGenerator.GetCategories().Select(cName => Category.Create(cName, cName));
            foreach (var category in categoryData)
            {
                await AddAsync(category);
            }


            int skip = 1;
            int take = int.MaxValue;
            var query = new GetCategoriesQuery()
            {
                Skip = skip,
                Take = take
            };
            BaseQueryResponse<CategoryResponse> res = await SendAsync(query);
            res.Success.Should().BeTrue();
            res.Count.Should().Be(categoryData.Count());
            res.Items.Should().NotBeEmpty();
            res.Items.Should().HaveCount(categoryData.Count()-1);
        }

        [Test]
        public async Task WhenTakeLessIsSpecifiedShouldReturnFromSkipToTake()
        {
            var categoryData = FakeDataGenerator.GetCategories().Select(cName => Category.Create(cName, cName));
            foreach (var category in categoryData)
            {
                await AddAsync(category);
            }

            int skip = 0;
            int take = 10;
            var query = new GetCategoriesQuery()
            {
                Skip = skip,
                Take = take
            };
            BaseQueryResponse<CategoryResponse> res = await SendAsync(query);
            res.Success.Should().BeTrue();
            res.Count.Should().Be(categoryData.Count());
            res.Items.Should().NotBeEmpty();
            res.Items.Should().HaveCount(10);
        }
    }
}
