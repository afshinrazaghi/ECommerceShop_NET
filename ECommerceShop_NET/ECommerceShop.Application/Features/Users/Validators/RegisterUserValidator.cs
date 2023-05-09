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
    public class RegisterUserValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email)
               .NotNull().WithMessage("Email is mandatory")
               .NotEmpty().WithMessage("Email is mandatory");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password is mandatory")
                .NotEmpty().WithMessage("Password is mandatory");
        }
    }
}
