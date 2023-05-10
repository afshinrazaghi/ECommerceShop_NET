using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using ECommerceShop.Domain.Common.Interfaces;
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
    public class Category : AggregateRoot<CategoryId>, IDomainBaseEntity
    {
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateModified { get; private set; }
        public DateTime? DeleteAt { get; private set; }

        public static Category Create(string name, string? description)
        {
            return new Category(name, description);
        }

        public Category UpdateCategory(string name, string? description)
        {
            Name = name;
            Description = description;
            return this;
        }

        private Category(string name, string? description)
        {
            Id = CategoryId.Create(Guid.NewGuid());
            Name = name;
            Description = description;
            DateCreated = DateTime.UtcNow;
        }

        public Category DeleteCategory(DateTime deleteAt)
        {
            DeleteAt = deleteAt;
            return this;
        }

        private Category() { }
    }
}
