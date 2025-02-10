using System.ComponentModel.DataAnnotations;

namespace Veil.Core.Common;

public abstract class BaseEntity : HasDomainEvents
{
    [Key]
    public int Id { get; set; }
}

public abstract class BaseEntity<T> : HasDomainEvents where T : IEquatable<T>
{
    [Key]
    public T Id { get; set; } = default!;
}
