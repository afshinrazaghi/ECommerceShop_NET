using ECommerceShop.Application.Common.Interfaces.Persistence;
using ECommerceShop.Domain.CategoryAggregate;
using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly ECommerceShopDbContext _context;

        public CategoryRepository(ECommerceShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryNameExist(CategoryId? id, string name)
        {
            return await _context.Categories.AnyAsync(c => (id == null || c.Id != id) && c.DeleteAt == null && c.Name == name);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(CategoryId id)
        {
            var dbCategory = await _context.Categories.FirstOrDefaultAsync(c=>c.Id == id);
            if (dbCategory != null)
            {
                dbCategory.DeleteCategory(DateTime.UtcNow);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IQueryable<Category> GetCategories(string? searchParam)
        {
            var query = _context.Categories.Where(c=>c.DeleteAt == null).AsQueryable();
            if (!string.IsNullOrEmpty(searchParam))
            {
                query = query.Where(c =>  c.Name.Contains(searchParam));
            }
            query.OrderBy(x => x.DateCreated);
            return query;
        }

        public async Task<Category?> GetCategory(CategoryId id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateCategory(CategoryId id, string name,string? description)
        {
            var dbCategory = await _context.Categories.FirstOrDefaultAsync(c=>c.Id == id);
            if (dbCategory != null)
            {
                dbCategory.UpdateCategory(name, description);
                await _context.SaveChangesAsync();
                return dbCategory;
            }
            else
            {
                return null;
            }
        }


    }
}
