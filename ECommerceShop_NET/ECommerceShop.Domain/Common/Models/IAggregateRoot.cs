

namespace ECommerceShop.Domain.Common.Models;

public interface IAggregateRoot<out TKey>
    where TKey : StronglyTypedId<Guid>
{
    TKey Id { get; }
    void ClearUncommittedEvents();
    IEnumerable<IDomainEvent> GetUncommittedEvents();
}
