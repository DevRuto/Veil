using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veil.Core.Common;
using Veil.Core.Entities;

namespace Veil.Core.Events;

public class MessageCreatedEvent : IDomainEvent
{
    public Message Message { get; set; }

    public MessageCreatedEvent(Message message) => Message = message;
}
