using Veil.Core.Common;
using Veil.Core.Entities;

namespace Veil.Core.Events;

public class MessageCreatedEvent : IDomainEvent
{
    public BaseMessage Message { get; set; }

    public MessageCreatedEvent(BaseMessage message) => Message = message;
}
