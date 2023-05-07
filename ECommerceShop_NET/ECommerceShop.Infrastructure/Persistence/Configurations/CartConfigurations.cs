using ECommerceShop.Domain.CartAggregate;
using ECommerceShop.Domain.CartAggregate.ValueObjects;
using ECommerceShop.Domain.ProductAggregate.ValueObjects;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            ConfigureCartTable(builder);
            ConfigureCartItemTable(builder);
        }

        private void ConfigureCartTable(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CartId.Create(value));

            builder.Property(c => c.UserId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));


            builder.Metadata.FindNavigation(nameof(Cart.CartItems))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureCartItemTable(EntityTypeBuilder<Cart> builder)
        {
            builder.OwnsMany(x => x.CartItems, ctb =>
            {

                ctb.ToTable("CartItem");

                ctb.WithOwner().HasForeignKey("CartId");

                ctb.HasKey(x => x.Id);

                ctb.Property(ct => ct.TotalPrice).HasColumnType("decimal(18,2)");

                ctb.Property(x => x.ProductId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProductId.Create(value));

                ctb.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CartItemId.Create(value));

            });
        }


    }
}
