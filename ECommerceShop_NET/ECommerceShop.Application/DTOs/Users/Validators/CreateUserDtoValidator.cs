using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.DTOs.Users.Validators
{
    internal class CreateUserDtoValidator:AbstractValidator<CreateUserRequsetDto>
    {
        public CreateUserDtoValidator()
        {
            Include(new IUserDtoValidator());

            RuleFor(x=>x.Password)
                .NotNull().WithMessage("Password is mandatory")
                .NotEmpty().WithMessage("Password is mandatory");
        }
    }
}
