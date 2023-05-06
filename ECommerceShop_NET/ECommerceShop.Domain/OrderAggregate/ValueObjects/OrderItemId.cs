using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.OrderAggregate.ValueObjects
{
    public class OrderItemId : StronglyTypedId<Guid>
    {
        public OrderItemId(Guid value) : base(value)
        {
        }

        public static OrderItemId Create(Guid value)
        {
            return new OrderItemId(value);
        }
    }
}
