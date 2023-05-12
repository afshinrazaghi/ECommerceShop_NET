using ECommerceShop.Application.Features.Users.Requests.Queries;
using ECommerceShop.Domain.UserAggregate;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Tests.Features.Users.Handlers.Queries
{
    using static Testing;
    public class CheckIsAdminQueryHandlerTests : TestBase
    {
        [Test]
        public async Task WhenUserIsEmptyReturnFalse()
        {
            var query = new CheckIsAdminQuery() { UserId = Guid.Empty };
            var res =async ()=> await SendAsync(query);
            await res.Should().ThrowAsync<System.Exception>().Where(e=>e.Message == "A valid id must be provided.");
        }


        [Test]
        public async Task WhenUserNotFoundReturnFalse()
        {
            var query = new CheckIsAdminQuery() { UserId = Guid.NewGuid() };
            bool res = await SendAsync(query);
            res.Should().BeFalse();
        }

        [Test]
        public async Task WhenUserNotAdminReturnFalse()
        {
            var user = await AddAsync(User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false));
            var query = new CheckIsAdminQuery() { UserId = user.Id.Value };
            bool res = await SendAsync(query);
            res.Should().BeFalse();
        }

        [Test]
        public async Task WhenUserIsAdminShouldReturnTrue()
        {
            var user = await AddAsync(User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", true));
            var query = new CheckIsAdminQuery() { UserId = user.Id.Value };
            bool res = await SendAsync(query);
            res.Should().BeTrue();
        }
    }
}
