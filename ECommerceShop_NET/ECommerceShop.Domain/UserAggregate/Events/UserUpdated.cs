using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.UserAggregate.Events
{
    public class UserUpdated : IDomainEvent
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ShippingAddress { get; set; }


        public static UserUpdated Create(
            Guid userId,
            string password,
            string firstName,
            string lastName,
            string shippingAddress)
        {
            return new UserUpdated(
                userId,
                password,
                firstName,
                lastName,
                shippingAddress);
        }


        private UserUpdated(
            Guid userId,
            string password,
            string firstName,
            string lastName,
            string shippingAddress)
        {
            UserId = userId;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            ShippingAddress = shippingAddress;

        }

    }
}
