using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.UserAggregate.Events
{
    public record class UserRegistered : IDomainEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsAdmin { get; set; }
        public string ShippingAddress { get; set; }

        public static UserRegistered Create(
            Guid userId,
            string email,
            string password,
            string firstName,
            string lastName,
            bool isAdmin,
            string shippingAddress)
        {
            return new UserRegistered(
                userId,
                email,
                password,
                firstName,
                lastName,
                isAdmin,
                shippingAddress
                );
        }


        private UserRegistered(
            Guid userId,
            string email,
            string password,
            string firstName,
            string lastName,
            bool isAdmin,
            string shippingAddress
            )
        {
            UserId = userId;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
            ShippingAddress = shippingAddress;
        }

    }
}
