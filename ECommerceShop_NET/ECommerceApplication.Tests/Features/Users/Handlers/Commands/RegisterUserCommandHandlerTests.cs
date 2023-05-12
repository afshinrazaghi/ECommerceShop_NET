using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Application.Responses;
using ECommerceShop.Contracts.Models.User.Responses;
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
    public class RegisterUserCommandHandlerTests : TestBase
    {
        [Test]
        public async Task WhenEmailEmptyReturnValidatorEmailError()
        {
            var command = new RegisterUserCommand("", "password");
            BaseCommandResponse<RegisterUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Email is mandatory");
        }

        [Test]
        public async Task WhenEmailInvalidReturnValidatorEmailError()
        {
            var command = new RegisterUserCommand("abc", "password");

            BaseCommandResponse<RegisterUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Email is invalid");
        }

        [Test]
        public async Task WhenPasswordIsEmptyReturnFailureWithPasswordError()
        {
            var command = new RegisterUserCommand("abc@gmail.com", "");

            BaseCommandResponse<RegisterUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Password is mandatory");
        }

        [Test]
        public async Task WhenPasswordLessThan6CharacterReturnFailureWithPasswordError()
        {
            var command = new RegisterUserCommand("abc@GMAIL.com", "12345");

            BaseCommandResponse<RegisterUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Password must be more than 6 character");
        }

        [Test]
        public async Task WhenEmailAlreadyExistReturnFailureWithEmailError()
        {
            var user = await AddAsync(User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false));
            var command = new RegisterUserCommand("a@b.com", "123456");

            BaseCommandResponse<RegisterUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Email already exists!");
        }

        [Test]
        public async Task RegisterSuccessfulWhenNoProblem()
        {
            var command = new RegisterUserCommand("a@b.com", "123456");
            BaseCommandResponse<RegisterUserResponse> res = await SendAsync(command);
            res.Success.Should().BeTrue();
            res.Message.Should().Be("User Registered Successfully!");
            res.Item!.Email.Should().Be(command.Email);
            res.Item!.Email.Should().NotBeEmpty();
            res.Item.Id.Should().NotBeEmpty();
        }
    }
}
