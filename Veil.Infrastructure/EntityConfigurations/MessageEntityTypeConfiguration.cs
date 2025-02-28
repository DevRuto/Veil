using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Veil.Core.Entities;

namespace Veil.Infrastructure.EntityConfigurations;

public class MessageEntityTypeConfiguration : IEntityTypeConfiguration<BaseMessage>
{
    public void Configure(EntityTypeBuilder<BaseMessage> builder)
    {
        builder.ToTable("Messages");

        builder.HasKey(m => m.Id);
        builder.Ignore(m => m.DomainEvents);

        // Dummy seed data
        var msgs = new List<BaseMessage>();
        for (var i = 0; i < 15; i++)
        {
            msgs.Add(new BaseMessage("Test text " + i));
        }
        builder.HasData(msgs.ToArray());
    }
}
