using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.DTOs.Users.Validators
{
    public class IUserDtoValidator : AbstractValidator<IUserDto>
    {
        public IUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email is mandatory")
                .NotEmpty().WithMessage("Email is mandatory")
                .EmailAddress().WithMessage("Email is not valid");
        }
    }
}
