using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerceShop.Domain.Common.Models
{
    public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
        where TKey : StronglyTypedId<Guid>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        protected AggregateRoot()
        {
            
        }
        public TKey Id { get; set; } = default!;
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AggregateId
        {
            get => Id.Value;
            set { }
        }

        public void ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        public IEnumerable<IDomainEvent> GetUncommittedEvents()
        {
           return _uncommittedEvents;
        }

        protected void AppendEvent(IDomainEvent @event)
        {
            _uncommittedEvents.Enqueue(@event);
        }

        [JsonIgnore]
        private readonly Queue<IDomainEvent> _uncommittedEvents = new Queue<IDomainEvent>();

      
    }
}
