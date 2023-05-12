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
    public class LoginCommandHandlerTests : TestBase
    {

        [Test]
        public async Task WhenEmailEmptyReturnValidatorErrorEmail()
        {
            var command = new LoginCommand()
            {
                Password = "password",
            };

            BaseCommandResponse<LoginUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Email is mandatory");
        }

        [Test]
        public async Task WhenEmailIsNotValidReturnValidatorErrorEmail()
        {
            var command = new LoginCommand()
            {
                Email = "abc",
                Password = "password",
            };

            BaseCommandResponse<LoginUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Email is invalid!");
        }

        [Test]
        public async Task WhenPasswordEmptyReturnValidatorErrorPassword()
        {
            var command = new LoginCommand()
            {
                Email = "a@b.com",
                Password = "",
            };

            BaseCommandResponse<LoginUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Password is mandatory");
        }

        [Test]
        public async Task WhenPasswordMinLengthLessThan6CharacterReturnValidatorErrorPassword()
        {
            var command = new LoginCommand()
            {
                Email = "a@b.com",
                Password = "12345",
            };

            BaseCommandResponse<LoginUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Password must be at least 6 characters");
        }

        [Test]
        public async Task WhenEmailNotExistReturnEmailOrPasswordIncorrect()
        {
            var command = new LoginCommand()
            {
                Email = "a@b.com",
                Password = "123456",
            };

            BaseCommandResponse<LoginUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Email or Password is incorrect");
        }

        [Test]
        public async Task WhenEmailAndPasswordNotMatchReturnEmailOrPasswordIncorrect()
        {
            await AddAsync(User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false));


            var command = new LoginCommand()
            {
                Email = "a@b.com",
                Password = "123457",
            };

            BaseCommandResponse<LoginUserResponse> res = await SendAsync(command);
            res.Success.Should().BeFalse();
            res.Message.Should().Be("Email or Password is incorrect");
        }

        [Test]
        public async Task ReturnSuccessfulWhenNoProblem()
        {
            var user = await AddAsync(User.Create("a@b.com", "$2a$10$xS.x8qAvbtXTAT3ow7kicuIwoNGbdyUxqS7qJwOizZPLcQFrBT2je", false));
            var command = new LoginCommand()
            {
                Email = "a@b.com",
                Password = "123456",
            };

            BaseCommandResponse<LoginUserResponse> res = await SendAsync(command);
            res.Success.Should().BeTrue();
            res.Message.Should().Be("User logged in successfully!");
            res.Item!.Email.Should().Be(user.Email);
            res.Item!.AccessToken.Should().NotBeEmpty();
            res.Item!.RefreshToken.Should().NotBeEmpty();

        }
    }
}
