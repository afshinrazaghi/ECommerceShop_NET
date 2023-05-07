using AutoMapper.Configuration;
using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(t => t.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.OwnsOne(x => x.ShippingAddress);

            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Password).HasMaxLength(100);

            builder.OwnsMany(m => m.UserTokenIds, utb =>
            {
                utb.ToTable("UserTokenIds");
                utb.WithOwner().HasForeignKey("UserId");
                utb.HasKey("Id");

                utb.Property(d => d.Value)
                .HasColumnName("UserTokenId")
                .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(User.UserTokenIds))!.
            SetPropertyAccessMode(PropertyAccessMode.Field);


        }
    }
}
