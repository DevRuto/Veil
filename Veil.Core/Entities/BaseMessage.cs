using Veil.Core.Common;
using Veil.Core.Enums;
using Veil.Core.Events;

namespace Veil.Core.Entities;

public class BaseMessage : BaseEntity<Guid>
{
    public string? Value { get; set; }
    public DataType DataType { get; set; }
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
    public Guid CreatedBy { get; set; }
    public DateTimeOffset? Updated { get; set;} = null;
    public Guid UpdatedBy { get; set; }

    public BaseMessage()
    {
        AddDomainEvent(new MessageCreatedEvent(this));
    }
}
