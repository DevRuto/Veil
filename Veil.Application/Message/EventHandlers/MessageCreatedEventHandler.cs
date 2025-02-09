using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        _logger.LogInformation("Message created, {Id}, {Text}", notification.Message.Id, notification.Message.Text);

        return Task.CompletedTask;
    }
}
