using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.OrderAggregate.ValueObjects;
using ECommerceShop.Domain.ProductAggregate;
using ECommerceShop.Domain.ProductAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.OrderAggregate.Entities
{
    public class OrderItem : Entity<OrderItemId>
    {
        public ProductId ProductId { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }

        private OrderItem()
        {
            
        }

    }
}
