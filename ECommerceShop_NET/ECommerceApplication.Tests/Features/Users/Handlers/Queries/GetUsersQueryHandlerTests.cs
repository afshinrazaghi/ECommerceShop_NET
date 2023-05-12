using Bogus;
using ECommerceShop.Application.Features.Users.Requests.Queries;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Requests;
using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Tests.Features.Users.Handlers.Queries
{
    using static Testing;
    public class GetUsersQueryHandlerTests : TestBase
    {
        [Test]
        public async Task ShouldReturnEmptyListWhenNoUserExist()
        {
            var query = new GetUsersQuery();
            BaseQueryResponse<UserResponse> res = await SendAsync(query);
            res.Success.Should().BeTrue();
            res.Items.Should().HaveCount(0);
        }

        [Test]
        public async Task WhenSkipIsGreaterThanZeroShouldReturnAfterSkipIndex()
        {
            Randomizer.Seed = new Random(8675309);
            List<User> users = new List<User>();


            for (int i = 0; i < 20; i++)
                users.Add(await AddAsync(User.Create(new Faker().Person.Email, "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false)));

            int skip = 2;
            int take = int.MaxValue;
            var query = new GetUsersQuery()
            {
                Skip = skip,
                Take = take
            };
            BaseQueryResponse<UserResponse> res = await SendAsync(query);
            res.Success.Should().BeTrue();
            res.Count.Should().Be(users.Count());
            res.Items.Should().HaveCount(users.Count() - skip);
        }


        [Test]
        public async Task WhenTakeIsPositiveNumberShouldReturnToTakeIndex()
        {
            Randomizer.Seed = new Random(8675309);
            List<User> users = new List<User>();

            for (int i = 0; i < 20; i++)
                users.Add(await AddAsync(User.Create(new Faker().Person.Email, "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false)));

            int skip = 0;
            int take = 10;
            var query = new GetUsersQuery()
            {
                Skip = skip,
                Take = take
            };
            BaseQueryResponse<UserResponse> res = await SendAsync(query);
            res.Success.Should().BeTrue();
            res.Count.Should().Be(users.Count());
            res.Items.Should().HaveCount(users.Count() - skip > take ? take : users.Count() - skip);
        }
    }
}
