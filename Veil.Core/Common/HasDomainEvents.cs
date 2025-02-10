using System.ComponentModel.DataAnnotations.Schema;

namespace Veil.Core.Common;

public abstract class HasDomainEvents
{
    [NotMapped]
    public List<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    public void AddDomainEvent(IDomainEvent domainEvent) => DomainEvents.Add(domainEvent);

    public void ClearDomainEvents() => DomainEvents.Clear();
}
