using ECommerceShop.Domain.CartAggregate.Entities;
using ECommerceShop.Domain.CartAggregate.ValueObjects;
using ECommerceShop.Domain.Common.Interfaces;
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
    public class Cart : AggregateRoot<CartId>, IDomainBaseEntity
    {
        private readonly List<CartItem> _cartItems = new ();
        public DateTime CreatedAt { get; set; }
        public UserId UserId { get; set; } = default!;
        public IReadOnlyList<CartItem> CartItems =>_cartItems.AsReadOnly();
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }

        public void AddCartItem(CartItem cartItem)
        {
            _cartItems.Add(cartItem);
        }


        public static Cart Create(Guid userId)
        {
            return new Cart(userId);
        }

       
        private Cart(Guid userId)
        {
            UserId = UserId.Create(userId);
            CreateAt = DateTime.UtcNow;
        }

        private Cart()
        {
            
        }
    }
}
