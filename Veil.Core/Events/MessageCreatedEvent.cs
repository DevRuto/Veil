using Veil.Core.Common;
using Veil.Core.Entities;

namespace Veil.Core.Events;

public class MessageCreatedEvent(BaseMessage message) : IDomainEvent
{
    public BaseMessage Message { get; set; } = message;
}
