using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Requests;
using ECommerceShop.Domain.UserAggregate;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Tests.Features.Users.Handlers.Commands
{
    using static Testing;
    public class UpdateUserCommandHandlerTests : TestBase
    {

        [Test]
        public async Task WhenIdIsEmptyReturnFailureWithIdError()
        {
            var command = new UpdateUserCommand() { FirstName = "a", LastName = "b" };
            BaseCommandResponse<UserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("User Id not found");
        }

        [Test]
        public async Task WhenFirstNameIsEmptyReturnFailureWithFirstNameError()
        {
            var command = new UpdateUserCommand() { Id = Guid.NewGuid(), LastName = "b" };
            BaseCommandResponse<UserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("First Name is mandatory");
        }

        [Test]
        public async Task WhenLastNameIsEmptyReturnFailureWithLastNameError()
        {
            var command = new UpdateUserCommand() { Id = Guid.NewGuid(), FirstName = "a" };
            BaseCommandResponse<UserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Last Name is mandatory");
        }

        [Test]
        public async Task WhenPasswordIsFilledButLessThan6CharacterReturnFailureWithPasswordError()
        {
            var command = new UpdateUserCommand() { Id = Guid.NewGuid(), FirstName = "a", LastName = "b", Password = "12345" };
            BaseCommandResponse<UserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Password must be at least 6 characters");
        }

        [Test]
        public async Task WhenUserIdNotFoundReturnFailureWithUserNotFound()
        {
            var command = new UpdateUserCommand() { Id = Guid.NewGuid(), FirstName = "a", LastName = "b", Password = "123456" };
            BaseCommandResponse<UserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("User not found");
        }

        [Test]
        public async Task UpdateUserSuccessfulWhenNoProblem()
        {
            var user = await AddAsync(User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false));

            var command = new UpdateUserCommand() { Id = user.Id.Value, FirstName = "afshin", LastName = "razaghi", Password = "123456" };
            BaseCommandResponse<UserResponse> res = await SendAsync(command);
            res.Success.Should().BeTrue();
            res.Message.Should().Be("User updated successfully!");
            res.Item!.FirstName.Should().Be(command.FirstName);
            res.Item!.LastName.Should().Be(command.LastName);
            if (!string.IsNullOrEmpty(command.Password))
            {
                var dbUser = await GetAsync<User>(user.Id);
                VerifyPassword(command.Password, dbUser!.Password);
            }

        }
    }
}
