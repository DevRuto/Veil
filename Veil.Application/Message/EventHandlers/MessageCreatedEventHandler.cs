using MediatR;

using Microsoft.Extensions.Logging;

using Veil.Core.Events;

namespace Veil.Application.Message.EventHandlers;

public class MessageCreatedEventHandler(ILogger<MessageCreatedEventHandler> logger) : INotificationHandler<MessageCreatedEvent>
{
    public Task Handle(MessageCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Message created, {Id} - {Type}, {Text}", notification.Message.Id, notification.Message.DataType, notification.Message.Value);

        return Task.CompletedTask;
    }
}
