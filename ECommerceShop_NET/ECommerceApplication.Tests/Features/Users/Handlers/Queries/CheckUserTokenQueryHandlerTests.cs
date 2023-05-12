using ECommerceShop.Domain.UserAggregate.Entities;
using ECommerceShop.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceShop.Application.Features.Users.Requests.Queries;
using FluentAssertions;

namespace ECommerceApplication.Tests.Features.Users.Handlers.Queries
{
    using static Testing;
    public class CheckUserTokenQueryHandlerTests : TestBase
    {
        [Test]
        public async Task WhenUserIsEmptyReturnFalse()
        {
            var query = new CheckIsAdminQuery() { UserId = Guid.Empty };
            var res = async () => await SendAsync(query);
            await res.Should().ThrowAsync<System.Exception>().Where(e => e.Message == "A valid id must be provided.");
        }

        [Test]
        public async Task WhenAccessTokenNotMatchReturnFailure()
        {
            var user = User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false);
            user.AddUserToken(UserToken.Create("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwNjc3MmY3NC01ZGI4LTQzNTktYjZhMi0xYzVjYjMzZjA5YmQiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQGFkbWluLmNvbSIsImVtYWlsIjoiYWRtaW5AYWRtaW4uY29tIiwiaXNBZG1pbiI6IlRydWUiLCJnaXZlbl9uYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiZXhwIjoxNjgzODI0NTU1LCJpc3MiOiJFQ29tbWVyY2VTaG9wIiwiYXVkIjoiRUNvbW1lcmNlU2hvcCJ9.F6Nf58KncNPwbHhOcvh9kNSyVigJC7fUwZZE2YCzeDQ", DateTime.Now.AddHours(5), "1209862f-b714-4f0d-908d-2ee2757ae16b", DateTime.Now.AddDays(1)));
            await AddAsync(user);
            var query = new CheckUserTokenQuery()
            {
                UserId = user.Id.Value,
                AccessToken = "eyZhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwNjc3MmY3NC01ZGI4LTQzNTktYjZhMi0xYzVjYjMzZjA5YmQiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQGFkbWluLmNvbSIsImVtYWlsIjoiYWRtaW5AYWRtaW4uY29tIiwiaXNBZG1pbiI6IlRydWUiLCJnaXZlbl9uYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiZXhwIjoxNjgzODI0NTT1LCJpc3MiOiJFQ29tbWVyY2VTaG9wIiwiYXVkIjoiRUNvbW1lcmNlU2hvcCJ9.F6Nf58KncNPwbHhOcvh9kNSyVigJC7fUwZZE2YCzeDQ"
            };

            var res = await SendAsync(query);
            res.Should().BeFalse();
        }

        [Test]
        public async Task ShouldReturnTrueWhenAccessTokenMatch()
        {
            var user = User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false);
            user.AddUserToken(UserToken.Create("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwNjc3MmY3NC01ZGI4LTQzNTktYjZhMi0xYzVjYjMzZjA5YmQiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQGFkbWluLmNvbSIsImVtYWlsIjoiYWRtaW5AYWRtaW4uY29tIiwiaXNBZG1pbiI6IlRydWUiLCJnaXZlbl9uYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiZXhwIjoxNjgzODI0NTU1LCJpc3MiOiJFQ29tbWVyY2VTaG9wIiwiYXVkIjoiRUNvbW1lcmNlU2hvcCJ9.F6Nf58KncNPwbHhOcvh9kNSyVigJC7fUwZZE2YCzeDQ", DateTime.Now.AddHours(5), "1209862f-b714-4f0d-908d-2ee2757ae16b", DateTime.Now.AddDays(1)));
            await AddAsync(user);

            var query = new CheckUserTokenQuery()
            {
                UserId = user.Id.Value,
                AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwNjc3MmY3NC01ZGI4LTQzNTktYjZhMi0xYzVjYjMzZjA5YmQiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQGFkbWluLmNvbSIsImVtYWlsIjoiYWRtaW5AYWRtaW4uY29tIiwiaXNBZG1pbiI6IlRydWUiLCJnaXZlbl9uYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiZXhwIjoxNjgzODI0NTU1LCJpc3MiOiJFQ29tbWVyY2VTaG9wIiwiYXVkIjoiRUNvbW1lcmNlU2hvcCJ9.F6Nf58KncNPwbHhOcvh9kNSyVigJC7fUwZZE2YCzeDQ"
            };

            var res = await SendAsync(query);
            res.Should().BeTrue();
        }


    }
}
