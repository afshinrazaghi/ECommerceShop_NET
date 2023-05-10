using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Categories.Requests.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory")
                .NotNull()
                .WithMessage("Name is mandatory")
                .MustAsync(async (name, token) =>
                {
                    return !await categoryRepository.CategoryNameExist(null, name);
                }).WithMessage("Category with this name already exist!");
        }
    }
}
