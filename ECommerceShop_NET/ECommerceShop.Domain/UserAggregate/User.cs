using ECommerceShop.Domain.Common.Interfaces;
using ECommerceShop.Domain.Common.Models;
using ECommerceShop.Domain.UserAggregate.Entities;
using ECommerceShop.Domain.UserAggregate.Events;
using ECommerceShop.Domain.UserAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ECommerceShop.Domain.UserAggregate
{
    [Table("User")]
    public class User : AggregateRoot<UserId>, IDomainBaseEntity
    {
        private readonly List<UserToken> _userTokens = new();

        #region Properties
        public string Email { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public bool IsAdmin { get; private set; }
        public Address? ShippingAddress { get; private set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public IReadOnlyList<UserToken> UserTokens => _userTokens.AsReadOnly();
        #endregion

        #region Public Methods

        public static User Create(Guid id, string email, string password, bool isAdmin)
        {
            return new User(id, email, password, isAdmin);

        }
        public static User Create(string email, string password, bool isAdmin)
        {
            return new User(email, password, isAdmin);
        }

        public void UpdateUser(string? firstName, string? lastName, string? shippingAddress, string? password)
        {
            FirstName = firstName;
            LastName = lastName;

            if (!string.IsNullOrWhiteSpace(shippingAddress))
                ShippingAddress = Address.Create(shippingAddress);

            if (!string.IsNullOrWhiteSpace(password))
                Password = password;
        }

        public void ClearUserTokens()
        {
            _userTokens.Clear();
        }

        public void AddUserToken(UserToken userToken)
        {
            if (_userTokens.All(ut => ut != userToken))
                _userTokens.Add(userToken);
        }

        public void RemoveUserToken(UserToken userToken)
        {
            if (_userTokens.Any(ut => ut == userToken))
                _userTokens.Remove(userToken);
        }

        #endregion

        #region Private Methods

        #endregion

        #region Constructor

        private User(string email, string password, bool isAdmin)
        {
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            CreateAt = DateTime.UtcNow;
        }

        private User(Guid id, string email, string password, bool isAdmin)
            : this(email, password, isAdmin)
        {
            Id = UserId.Create(id);
        }

        private User() { }
        #endregion
    }
}
