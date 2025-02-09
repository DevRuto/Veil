using Microsoft.EntityFrameworkCore;

using Veil.Core.Entities;
using Veil.Infrastructure.EntityConfigurations;

namespace Veil.Infrastructure;

public class VeilContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
    }
}
