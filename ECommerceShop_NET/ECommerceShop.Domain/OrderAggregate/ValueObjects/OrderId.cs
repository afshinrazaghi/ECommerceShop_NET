using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.OrderAggregate.ValueObjects
{
    public class OrderId : StronglyTypedId<Guid>
    {
        public OrderId(Guid value) : base(value)
        {
        }
        public static OrderId Create(Guid value)
        {
            return new OrderId(value);
        }
    }
}
