using ECommerceShop.Domain.UserAggregate;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            //builder.Property(t => t.AggregateId)
            //    .ValueGeneratedOnAdd()
            //    .HasDefaultValueSql("newsequentialid()");

            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newsequentialid()")
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.OwnsOne(x => x.ShippingAddress);

            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Password).HasMaxLength(100);

            builder.OwnsMany(m => m.UserTokens, utb =>
            {
                utb.ToTable("UserTokens");
                utb.WithOwner().HasForeignKey("UserId");
                utb.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newsequentialid()")
                .HasConversion(
                    id => id.Value,
                    value => UserTokenId.Create(value));
            });

            //builder.HasData(User.Create(Guid.NewGuid(), "login@test.com", "$2a$10$d.elewc4L65Ja/urk5Gp7.HbGlA84o3tH0.C6SX4O7Jq63sWoG3k2", true));

        }
    }
}
