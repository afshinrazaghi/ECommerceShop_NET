using ECommerceShop.Domain.CartAggregate.ValueObjects;
using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.ProductAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.CartAggregate.Entities
{
    public class CartItem : Entity<CardItemId>
    {
        public ProductId ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
