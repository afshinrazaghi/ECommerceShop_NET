using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.UserAggregate.ValueObjects
{
    public class UserId : StronglyTypedId<Guid>
    {
        public UserId(Guid value) : base(value)
        {
        }


        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }
    }
}
