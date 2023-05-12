using ECommerceShop.Application.Features.Users.Requests.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Email is mandatory");

            RuleFor(l => l.Email)
                .EmailAddress().When(l => !string.IsNullOrEmpty(l.Email)).WithMessage("Email is invalid!");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Password is mandatory");

                RuleFor(l => l.Password)
                .MinimumLength(6).When(l => !string.IsNullOrEmpty(l.Password)).WithMessage("Password must be at least 6 characters");
                
        }
    }
}
