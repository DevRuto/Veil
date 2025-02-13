using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Veil.Application.Interfaces;

namespace Veil.Application.Message.Queries;

public record GetMessagesQuery : IRequest<MessageDto[]>
{
    
}

public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, MessageDto[]>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMessagesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MessageDto[]> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Messages
            .ProjectTo<MessageDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken: cancellationToken);
    }
}