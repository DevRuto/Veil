using MediatR;

using Microsoft.Extensions.Logging;

using Veil.Application.Interfaces;
using Veil.Core.Entities;

namespace Veil.Application.Message.Commands;

public record CreateMessageCommand : IRequest<Guid>
{
    public string? Text { get; set; }
}

public class CreateMessageCommandHandler(IApplicationDbContext context, ILogger<CreateMessageCommandHandler> logger) : IRequestHandler<CreateMessageCommand, Guid>
{
    public async Task<Guid> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Called CreateMessageCommandHandler");
        var msg = TextMessage.Create(request.Text) as BaseMessage;
        var entity = await context.Messages.AddAsync(msg, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity.Entity.Id;
    }
}
