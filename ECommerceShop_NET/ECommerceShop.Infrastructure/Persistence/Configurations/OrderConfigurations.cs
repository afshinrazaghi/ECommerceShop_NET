using ECommerceShop.Domain.OrderAggregate;
using ECommerceShop.Domain.OrderAggregate.ValueObjects;
using ECommerceShop.Domain.ProductAggregate.ValueObjects;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            ConfigureOrderTable(builder);
            ConfigureOrderItemTable(builder);
        }

        private void ConfigureOrderTable(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(o => o.AggregateId);

            builder.Property(o => o.AggregateId)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("newsequentialid()"); ;

            builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");

            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => OrderId.Create(value));

            builder.Property(o => o.UserId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.Metadata.FindNavigation(nameof(Order.OrderItems))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureOrderItemTable(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsMany(o => o.OrderItems, oib =>
            {
                oib.ToTable("OrderItem");

                oib.WithOwner().HasForeignKey("OrderId");

                oib.Property(oi => oi.Price).HasColumnType("decimal(18,2)");

                oib.Property(oi => oi.ProductId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProductId.Create(value));

                oib.HasKey(oi => oi.Id);

                oib.Property(o => o.Id)
                .ValueGeneratedNever()
                .HasConversion(
                        id => id.Value,
                        value => OrderItemId.Create(value));

            });
        }


    }
}
