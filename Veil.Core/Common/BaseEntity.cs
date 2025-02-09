using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Veil.Core.Common;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }

    [NotMapped]
    public List<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    public void AddDomainEvent(IDomainEvent domainEvent) => DomainEvents.Add(domainEvent);
}

public abstract class BaseEntity<T> where T : IEquatable<T>
{
    [Key]
    public T Id { get; set; } = default!;

    [NotMapped]
    public List<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    public void AddDomainEvent(IDomainEvent domainEvent) => DomainEvents.Add(domainEvent);
}
