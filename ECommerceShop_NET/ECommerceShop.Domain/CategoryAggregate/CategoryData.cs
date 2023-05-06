using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.CategoryAggregate
{
    public class CategoryData
    {
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
    }
}
