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
        private readonly List<OrderItem> _orderItems = new();
        public UserId UserId { get; set; } = default!;
        public string OrderNumber { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }

        public static Order Create(OrderData orderData)
        {
            return new Order(orderData);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            _orderItems.Remove(orderItem);
        }


        private Order(OrderData orderData)
        {
            UserId = UserId.Create(orderData.UserId);
            OrderNumber = orderData.OrderNumber;
            TotalAmount = orderData.TotalAmount;
            OrderDate = orderData.OrderDate;
        }


        private Order() { }
    }
}
