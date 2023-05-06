using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.ProductAggregate
{
    public class ProductData
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string SKU { get; set; } = default!;
        public double Price { get; set; }
        public Guid CategoryId { get; set; } = default!;
    }
}
