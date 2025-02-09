using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veil.Core.Common;
using Veil.Core.Events;

namespace Veil.Core.Entities;

public class Message : BaseEntity<Guid>
{
    public required string Text { get; set; }

    public static Message Create(string text)
    {
        var message = new Message
        {
            Id = Guid.NewGuid(),
            Text = text
        };

        message.AddDomainEvent(new MessageCreatedEvent(message));

        return message;
    }
}
