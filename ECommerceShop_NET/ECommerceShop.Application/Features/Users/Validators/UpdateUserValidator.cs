using ECommerceShop.Application.Features.Users.Requests.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Users.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotNull().WithMessage("First Name is mandatory")
                .NotEmpty().WithMessage("First Name is mandatory");

            RuleFor(u => u.LastName)
                .NotNull().WithMessage("Last Name is mandatory")
                .NotEmpty().WithMessage("Last Name is mandatory");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("Password is mandatory")
                .NotEmpty().WithMessage("Password is mandatory")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        }
    }
}
