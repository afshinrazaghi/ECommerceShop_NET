using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Application.Responses;
using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.UserAggregate.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Tests.Features.Users.Handlers.Commands
{
    using static Testing;
    public class LogoutUserCommandHandlerTests : TestBase
    {
        [Test]
        public async Task WhenUserNotFoundReturnNotFound()
        {
            var command = new LogoutUserCommand()
            {
                UserId = Guid.NewGuid(),
            };

            BaseCommandResponse res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("User not found!");
        }

        [Test]
        public async Task LogoutSuccessfulWhenNotProblem()
        {
            var user = User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false);
            user.AddUserToken(UserToken.Create("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwNjc3MmY3NC01ZGI4LTQzNTktYjZhMi0xYzVjYjMzZjA5YmQiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQGFkbWluLmNvbSIsImVtYWlsIjoiYWRtaW5AYWRtaW4uY29tIiwiaXNBZG1pbiI6IlRydWUiLCJnaXZlbl9uYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiZXhwIjoxNjgzODI0NTU1LCJpc3MiOiJFQ29tbWVyY2VTaG9wIiwiYXVkIjoiRUNvbW1lcmNlU2hvcCJ9.F6Nf58KncNPwbHhOcvh9kNSyVigJC7fUwZZE2YCzeDQ", DateTime.Now.AddHours(5), "1209862f-b714-4f0d-908d-2ee2757ae16b", DateTime.Now.AddDays(1)));
            await AddAsync(user);

            var command = new LogoutUserCommand()
            {
                UserId = user.Id.Value
            };

            BaseCommandResponse res = await SendAsync(command);
            res.Success.Should().BeTrue();
            var dbUser = await GetAsync<User>(user.Id, "UserTokens");
            dbUser!.UserTokens.Should().BeEmpty();
        }
    }
}
