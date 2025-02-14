using Microsoft.EntityFrameworkCore;

using Veil.Core.Entities;

namespace Veil.Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<BaseMessage> Messages { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
