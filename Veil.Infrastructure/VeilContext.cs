using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Veil.Core.Common;
using Veil.Core.Entities;
using Veil.Infrastructure.EntityConfigurations;

namespace Veil.Infrastructure;

public class VeilContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    private readonly IMediator _mediator;
    private readonly ILogger<VeilContext> _logger;

    public VeilContext(IMediator mediator, ILogger<VeilContext> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var domainEntities = ChangeTracker.Entries<HasDomainEvents>()
            .Select(e => e.Entity)        
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        foreach (var domainEntity in domainEntities)
        {
            var events = domainEntity.DomainEvents.ToArray();
            domainEntity.ClearDomainEvents();
            foreach (var domainEvent in events)
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
        }

        return result;
    }
}
