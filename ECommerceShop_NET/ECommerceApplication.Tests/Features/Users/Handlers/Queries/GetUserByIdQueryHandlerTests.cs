using ECommerceShop.Application.Features.Users.Requests.Queries;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Requests;
using ECommerceShop.Domain.UserAggregate;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Tests.Features.Users.Handlers.Queries
{
    using static Testing;
    public class GetUserByIdQueryHandlerTests : TestBase
    {
        [Test]
        public async Task WhenUserIsEmptyReturnFalse()
        {
            var query = new CheckIsAdminQuery() { UserId = Guid.Empty };
            var res = async () => await SendAsync(query);
            await res.Should().ThrowAsync<System.Exception>().Where(e => e.Message == "A valid id must be provided.");
        }

        [Test]
        public async Task WhenUserIdNotExistReturnFailureUserNotFound()
        {
            var query = new GetUserByIdQuery()
            {
                UserId = Guid.NewGuid()
            };

            BaseQueryResponse<UserResponse> res = await SendAsync(query);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("User not found!");
        }


        [Test]
        public async Task ReturnUserSuccessfullyWhenNoProblem()
        {
            var user = await AddAsync(User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false));
            var query = new GetUserByIdQuery()
            {
                UserId = user.Id.Value
            };

            BaseQueryResponse<UserResponse> res = await SendAsync(query);
            res.Success.Should().BeTrue();
            res.Message.Should().BeNull();
            res.Item!.Email.Should().Be(user.Email);
        }

    }
}
