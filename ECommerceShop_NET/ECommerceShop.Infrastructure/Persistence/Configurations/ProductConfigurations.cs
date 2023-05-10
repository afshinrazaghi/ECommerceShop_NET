using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using ECommerceShop.Domain.ProductAggregate;
using ECommerceShop.Domain.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ConfigureProductTable(builder);
        }

        private void ConfigureProductTable(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(b => b.AggregateId);

            builder.Property(b => b.AggregateId)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("newsequentialid()"); ;

            builder.Property(b => b.CategoryId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CategoryId.Create(value));

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newsequentialid()")
                .HasConversion(
                    id => id.Value,
                    value => ProductId.Create(value));
        }
    }
}
