using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.ProductAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.ProductAggregate
{
    [Table("Product")]
    public class Product : AggregateRoot<ProductId>
    {
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
        public string SKU { get; private set; } = default!;
        public double Price { get; private set; }
        public CategoryId CategoryId { get; private set; } = default!;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }

        public static Product Create(ProductData productData)
        {
            return new Product(productData);
        }

        private Product(ProductData productData)
        {
            Id = ProductId.Create(Guid.NewGuid());
            Name = productData.Name;
            Description = productData.Description;
            SKU = productData.SKU;
            Price = productData.Price;
            CategoryId = CategoryId.Create(productData.CategoryId);
            CreateAt = DateTime.UtcNow;
        }

        private Product()
        {

        }
    }
}
