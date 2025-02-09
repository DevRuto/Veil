using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
