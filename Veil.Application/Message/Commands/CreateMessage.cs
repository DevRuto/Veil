using MediatR;

using Microsoft.Extensions.Logging;

using Veil.Application.Interfaces;

namespace Veil.Application.Message.Commands;

public record CreateMessageCommand : IRequest<Guid>
{
    public string? Text { get; set; }
}

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateMessageCommandHandler> _logger;

    public CreateMessageCommandHandler(IApplicationDbContext context, ILogger<CreateMessageCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Called CreateMessageCommandHandler");
        var entity = await _context.Messages.AddAsync(Core.Entities.Message.Create(request.Text));
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Entity.Id;
    }
}
