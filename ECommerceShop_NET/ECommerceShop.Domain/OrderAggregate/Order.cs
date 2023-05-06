using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.OrderAggregate.Entities;
using ECommerceShop.Domain.OrderAggregate.ValueObjects;
using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.OrderAggregate
{
    public class Order : AggregateRoot<OrderId>
    {
        private readonly List<OrderItem> _orderItems;
        public UserId UserId { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public IReadOnlyList<OrderItem> OrderItems => _orderItems;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
    }
}
