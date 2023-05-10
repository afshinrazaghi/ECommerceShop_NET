using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Application.Features.Categories.Requests.Commands;
using ECommerceShop.Contracts.Models.Category.Responses;
using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Features.Categories.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(c => c.Name)
                   .NotEmpty()
                   .WithMessage("Name is mandatory")
                   .NotNull()
                   .WithMessage("Name is mandatory");

            RuleFor(c=>c)
                .MustAsync(async (updateCategoryCommand, token) =>
                {
                    return !await categoryRepository.CategoryNameExist(CategoryId.Create(updateCategoryCommand.Id), updateCategoryCommand.Name);
                }).WithMessage("Category with this name already exist!");
        }
    }
}
