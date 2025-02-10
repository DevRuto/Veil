using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Veil.Application.Interfaces;

namespace Veil.Application.Message.Queries;

public record GetMessagesQuery : IRequest<Core.Entities.Message[]>
{
    
}

public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, Core.Entities.Message[]>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<GetMessagesQueryHandler> _logger;

    public GetMessagesQueryHandler(IApplicationDbContext context, ILogger<GetMessagesQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Core.Entities.Message[]> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetMessages Query");
        return await _context.Messages.ToArrayAsync();
    }
}