using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Veil.Application.Interfaces;

namespace Veil.Application.Message.Queries;

public record GetMessagesQuery : IRequest<MessageDto[]>
{
    
}

public class GetMessagesQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetMessagesQuery, MessageDto[]>
{
    public async Task<MessageDto[]> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        return await context.Messages
            .ProjectTo<MessageDto>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken: cancellationToken);
    }
}