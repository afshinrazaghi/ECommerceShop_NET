using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.CartAggregate.ValueObjects
{
    public class CartId : StronglyTypedId<Guid>
    {
        public CartId(Guid value) : base(value)
        {
        }
        public static CartId Create(Guid value)
        {
            return new CartId(value);
        }
    }
}
