using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.Common.Models
{
    public abstract class AggregateRootId<TId> : ValueObject<TId>
    {
        public abstract TId Value { get; protected set; }

    }
}
