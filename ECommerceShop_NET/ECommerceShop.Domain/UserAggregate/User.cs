using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.UserAggregate.Events;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceShop.Domain.UserAggregate
{
    [Table("User")]
    public class User : AggregateRoot<UserId>
    {
        public string Email { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public bool IsAdmin { get; private set; }
        public Address ShippingAddress { get; private set; } = default!;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }

        public static User Create(UserData userData)
        {
            return new User(userData);
        }

        private void Apply(UserRegistered registered)
        {
            Id = UserId.Create(registered.UserId);
            Email = registered.Email;
            Password = registered.Password;
            FirstName = registered.FirstName;
            LastName = registered.LastName;
            IsAdmin = registered.IsAdmin;
            ShippingAddress = Address.Create(registered.ShippingAddress);
            CreateAt = DateTime.UtcNow;
        }

        private void Apply(UserUpdated updated)
        {
            Password = updated.Password;
            FirstName = updated.FirstName;
            LastName = updated.LastName;
            ShippingAddress = Address.Create(updated.ShippingAddress);
            ModifyAt = DateTime.UtcNow;
        }

        public void UpdateUserInformation(UserData userData)
        {
            var @event = UserUpdated.Create(
                Id.Value,
                userData.Password,
                userData.FirstName,
                userData.LastName,
                userData.ShippingAddress);

            AppendEvent(@event);
            Apply(@event);
        }

        private User(UserData userData)
        {
            var @event = UserRegistered.Create(
                Guid.NewGuid(),
                userData.Email,
                userData.Password,
                userData.FirstName,
                userData.LastName,
                userData.IsAdmin,
                userData.ShippingAddress
                );

            AppendEvent(@event);
            Apply(@event);
        }

        private User() { }
    }
}
