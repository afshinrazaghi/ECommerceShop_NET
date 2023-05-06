using ECommerceShop.Domain.CartAggregate.Entities;
using ECommerceShop.Domain.CartAggregate.ValueObjects;
using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.CartAggregate
{
    public class Cart : AggregateRoot<CartId>
    {
        private readonly List<CartItem> _cartItems = new ();
        public DateTime CreatedAt { get; set; }
        public UserId UserId { get; set; }
        public IReadOnlyList<CartItem> CartItems =>_cartItems;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
    }
}
