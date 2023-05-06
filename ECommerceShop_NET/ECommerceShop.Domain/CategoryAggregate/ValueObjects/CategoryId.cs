using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.CategoryAggregate.ValueObjects
{
    public class CategoryId : StronglyTypedId<Guid>
    {
        public CategoryId(Guid value) : base(value)
        {
        }

        public static CategoryId Create(Guid value)
        {
            return new CategoryId(value);
        }
    }
}
