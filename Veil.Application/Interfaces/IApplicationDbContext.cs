using Microsoft.EntityFrameworkCore;

namespace Veil.Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Core.Entities.Message> Messages { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
