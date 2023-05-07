using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.OrderAggregate
{
    public class OrderData
    {
        public Guid UserId { get; set; } = default!;
        public string OrderNumber { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
