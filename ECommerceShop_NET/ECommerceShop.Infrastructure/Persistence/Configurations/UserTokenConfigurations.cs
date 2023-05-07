using ECommerceShop.Domain.UserAggregate.ValueObjects;
using ECommerceShop.Domain.UserTokenAggregate;
using ECommerceShop.Domain.UserTokenAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Infrastructure.Persistence.Configurations
{
    public class UserTokenConfigurations : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            ConfigureUserTokenTable(builder);
        }

        private void ConfigureUserTokenTable(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserToken");

            builder.HasKey(ut => ut.Id);

            builder.Property(ut => ut.UserId)
               .ValueGeneratedNever()
               .HasConversion(
                   id => id.Value,
                   value => UserId.Create(value));

            builder.Property(ut => ut.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserTokenId.Create(value));
        }
    }
}
