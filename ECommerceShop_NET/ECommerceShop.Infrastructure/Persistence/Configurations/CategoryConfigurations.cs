using ECommerceShop.Domain.CategoryAggregate;
using ECommerceShop.Domain.CategoryAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            ConfigureCategoryTable(builder);
        }

        private void ConfigureCategoryTable(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.AggregateId);

            builder.Property(c => c.AggregateId)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("newsequentialid()"); ;

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CategoryId.Create(value));


        }
    }
}
