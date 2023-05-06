using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.CategoryAggregate
{
    [Table("Category")]
    public class Category : AggregateRoot<CategoryId>
    {
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateModified { get; private set; }

        public static Category Create(CategoryData categoryData)
        {
            return new Category(categoryData);
        }

        private Category(CategoryData categoryData)
        {
            Id = CategoryId.Create(Guid.NewGuid());
            Name = categoryData.Name;
            Description = categoryData.Description;
            DateCreated = DateTime.UtcNow;
        }
    }
}
