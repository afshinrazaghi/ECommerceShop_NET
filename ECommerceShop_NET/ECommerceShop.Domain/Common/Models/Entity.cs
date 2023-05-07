using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.Common.Models
{
    public abstract class Entity<TKey> 
        where TKey: StronglyTypedId<Guid>
    {
        protected Entity()
        {
            
        }
        public TKey Id { get; set; } = default!;
        public override bool Equals(object? obj)
        {
            return obj is Entity<TKey> entity && Id.Equals(entity.Id);
        }

        public bool Equals(TKey? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
