using MediatR;

using Microsoft.Extensions.Logging;

using Veil.Application.Interfaces;
using Veil.Core.Entities;
using Veil.Core.Enums;

namespace Veil.Application.Message.Commands;

public record CreateMessageCommand : IRequest<Guid?>
{
    public DataType DataType { get; set; } = DataType.Text;
    public string? Text { get; set; }
    public byte[]? Value { get; set; }
}

public class CreateMessageCommandHandler(IApplicationDbContext context, ILogger<CreateMessageCommandHandler> logger) : IRequestHandler<CreateMessageCommand, Guid?>
{
    public async Task<Guid?> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Called CreateMessageCommandHandler");
        if (!string.IsNullOrEmpty(request.Text))
        {
            var entity = await context.Messages.AddAsync(new BaseMessage(request.Text), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return entity.Entity.Id;
        }
        return null;
    }
}
