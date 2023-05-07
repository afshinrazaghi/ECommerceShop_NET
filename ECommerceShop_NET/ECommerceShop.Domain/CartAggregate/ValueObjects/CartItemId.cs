using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.CartAggregate.ValueObjects
{
    public class CartItemId : StronglyTypedId<Guid>
    {
        public CartItemId(Guid value) : base(value)
        {
        }

        public static CartItemId Create(Guid value)
        {
            return new CartItemId(value);
        }
    }
}
