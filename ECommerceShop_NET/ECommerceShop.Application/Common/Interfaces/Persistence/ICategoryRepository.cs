using ECommerceShop.Domain.CategoryAggregate;
using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Application.Common.Interfaces.Persistence
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategory(CategoryId id);
        public IQueryable<Category> GetCategories(string? searchParam);

        public Task<bool> CategoryNameExist(CategoryId? id, string name);

        public Task<Category> CreateCategory(Category category);

        public Task<Category?> UpdateCategory(CategoryId id, string name, string? description);

        public Task<bool> DeleteCategory(CategoryId id);
    }
}
