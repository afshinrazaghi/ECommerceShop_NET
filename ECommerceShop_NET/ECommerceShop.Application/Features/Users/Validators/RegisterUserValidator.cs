using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Users.Requests.Commands;
using ECommerceShop.Contracts.Models.User.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
               .NotNull().WithMessage("Email is mandatory")
               .NotEmpty().WithMessage("Email is mandatory");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password is mandatory")
                .NotEmpty().WithMessage("Password is mandatory")
                .MinimumLength(6).WithMessage("Password must be more than 6 character");

            RuleFor(x => x.Email)
                .MustAsync(async (email, token) =>
                {
                    return !await userRepository.EmailExist(email);
                }).WithMessage("Email already exists!");
        }
    }
}
