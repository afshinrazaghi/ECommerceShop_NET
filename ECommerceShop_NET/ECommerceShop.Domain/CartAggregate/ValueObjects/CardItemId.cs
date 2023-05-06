using ECommerceShop.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.CartAggregate.ValueObjects
{
    public class CardItemId : StronglyTypedId<Guid>
    {
        public CardItemId(Guid value) : base(value)
        {
        }

        public static CardItemId Create(Guid value)
        {
            return new CardItemId(value);
        }
    }
}
