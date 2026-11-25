using ChatCraft.Domain.Models.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatCraft.Infrastructure.Mapping;

public class InboundEventMap : IEntityTypeConfiguration<InboundEvent>
{
    public void Configure(EntityTypeBuilder<InboundEvent> builder)
    {
        builder.ToTable("inbox_events");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.EventKey)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ReceivedAtUtc)
            .IsRequired();

        builder.Property(x => x.OccurredAtUtc)
            .IsRequired(false);

        builder.Property(x => x.Payload)
            .IsRequired()
            .HasColumnType("jsonb");

        builder.HasIndex(x => new { x.AccountId, x.EventKey }).IsUnique();

        builder.HasDiscriminator<string>("event_type")
            .HasValue<CommentReceived>("comment_received")
            .HasValue<InteractionReceived>("interaction_received");
    }
}
