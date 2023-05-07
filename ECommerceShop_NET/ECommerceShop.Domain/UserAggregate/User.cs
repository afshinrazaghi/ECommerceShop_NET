using ECommerceShop.Domain.Common.Interfaces;
using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.UserAggregate.Entities;
using ECommerceShop.Domain.UserAggregate.Events;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using ECommerceShop.Domain.UserTokenAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ECommerceShop.Domain.UserAggregate
{
    [Table("User")]
    public class User : AggregateRoot<UserId>, IDomainBaseEntity
    {
        private readonly List<UserTokenId> _userTokenIds;

        #region Properties
        public string Email { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public bool IsAdmin { get; private set; }
        public Address ShippingAddress { get; private set; } = default!;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public IReadOnlyList<UserTokenId> UserTokenIds => _userTokenIds.AsReadOnly();
        #endregion

        #region Public Methods
        public static User Create(UserData userData)
        {
            return new User(userData);
        }

        public void AddUserToken(UserToken userToken)
        {
            _userTokens.Add(userToken);
        }

        public void RemoveUserToken(UserToken userToken)
        {
            _userTokens.Remove(userToken);
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
            ApplyUpdateInfo(@event);
        } 
        #endregion

        #region Private Methods
        private void ApplyRegisterInfo(UserRegistered registered)
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

        private void ApplyUpdateInfo(UserUpdated updated)
        {
            Password = updated.Password;
            FirstName = updated.FirstName;
            LastName = updated.LastName;
            ShippingAddress = Address.Create(updated.ShippingAddress);
            ModifyAt = DateTime.UtcNow;
        } 
        #endregion

        #region Constructor
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
            ApplyRegisterInfo(@event);
        }

        private User() { } 
        #endregion
    }
}
