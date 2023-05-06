using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.ProductAggregate;
using ECommerceShop.Domain.CategoryAggregate;
using ECommerceShop.Domain.OrderAggregate;
using ECommerceShop.Domain.OrderAggregate.Entities;
using ECommerceShop.Domain.CartAggregate;
using ECommerceShop.Domain.CartAggregate.Entities;

namespace ECommerceShop.Infrastructure.Persistence
{
    public class ECommerceShopDbContext : DbContext
    {
        public ECommerceShopDbContext(DbContextOptions<ECommerceShopDbContext> options)
            : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
