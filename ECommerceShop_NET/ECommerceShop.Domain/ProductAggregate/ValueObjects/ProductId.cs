using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.ProductAggregate.ValueObjects
{
    public class ProductId : StronglyTypedId<Guid>
    {
        public ProductId(Guid value) : base(value)
        {
        }

        public static ProductId Create(Guid value)
        {
            return new ProductId(value);
        }
    }
}
