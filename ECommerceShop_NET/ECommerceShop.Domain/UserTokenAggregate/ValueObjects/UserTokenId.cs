using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.UserTokenAggregate.ValueObjects
{
    public class UserTokenId : StronglyTypedId<Guid>
    {
        public UserTokenId(Guid value) : base(value)
        {
        }

        public static UserTokenId Create(Guid value)
        {
            return new UserTokenId(value);
        }
    }
}
