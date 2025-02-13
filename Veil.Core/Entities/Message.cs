using Veil.Core.Common;
using Veil.Core.Events;

namespace Veil.Core.Entities;

public class Message : BaseEntity<Guid>
{
    public string? Text { get; set; }

    public static Message Create(string? text)
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
