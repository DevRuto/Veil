using MediatR;

using Microsoft.Extensions.Logging;

using Veil.Application.Interfaces;

namespace Veil.Application.Message.Commands;

public record CreateMessageCommand : IRequest<int>
{
    public string? Text { get; set; }
}

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateMessageCommandHandler> _logger;

    public CreateMessageCommandHandler(IApplicationDbContext context, ILogger<CreateMessageCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Called CreateMessageCommandHandler");
        _context.Messages.Add(Core.Entities.Message.Create(request.Text));
        await _context.SaveChangesAsync(cancellationToken);
        return 5;
    }
}
