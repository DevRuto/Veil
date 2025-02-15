using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Veil.Application.Interfaces;
using Veil.Core.Common;
using Veil.Core.Entities;
using Veil.Infrastructure.EntityConfigurations;

namespace Veil.Infrastructure;

public class VeilContext(
    DbContextOptions<VeilContext> options,
    IMediator mediator,
    ILogger<VeilContext> logger) : DbContext(options), IApplicationDbContext
{
    public DbSet<BaseMessage> Messages { get; set; }

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
                await mediator.Publish(domainEvent).ConfigureAwait(false);
            
            logger.LogInformation("Domain events dispatched");
        }

        return result;
    }
}
