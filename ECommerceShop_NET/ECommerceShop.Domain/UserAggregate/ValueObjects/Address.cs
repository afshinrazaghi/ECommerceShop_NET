using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.UserAggregate.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string StreetAddress { get; private set; }

        public static Address Create(string address)
        {
            return new Address(address);
        }

        private Address(string address)
        {
            StreetAddress = address;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
           yield return StreetAddress;
        }
    }
}
