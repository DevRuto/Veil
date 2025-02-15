using MediatR;

using Microsoft.Extensions.Logging;

using Veil.Core.Events;

namespace Veil.Application.Message.EventHandlers;

public class MessageCreatedEventHandler : INotificationHandler<MessageCreatedEvent>
{
    private readonly ILogger<MessageCreatedEventHandler> _logger;

    public MessageCreatedEventHandler(ILogger<MessageCreatedEventHandler> logger) => _logger = logger;

    public Task Handle(MessageCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Message created, {Id} - {Type}, {Text}", notification.Message.Id, notification.Message.DataType, notification.Message.Value);

        return Task.CompletedTask;
    }
}
