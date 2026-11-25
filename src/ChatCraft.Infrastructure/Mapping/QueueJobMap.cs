using ChatCraft.Domain.Models.Account;
using ChatCraft.Domain.Models.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatCraft.Infrastructure.Mapping;

public class QueueJobMap : IEntityTypeConfiguration<QueueJob>
{
    public void Configure(EntityTypeBuilder<QueueJob> builder)
    {
        builder.ToTable("queue_jobs");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.ActionKey)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Type)
            .IsRequired()
            .HasColumnType("smallint");

        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnType("smallint");

        builder.Property(x => x.DueAtUtc)
            .IsRequired();

        builder.Property(x => x.LeaseUntilUtc)
            .IsRequired(false);

        builder.Property(x => x.LeaseVersion)
            .IsRequired();

        builder.Property(x => x.AttemptCount)
            .IsRequired();

        builder.HasOne<InstagramAccount>()
            .WithMany()
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(job => job.InboundEvent)
            .WithMany()
            .HasForeignKey(job => new { job.AccountId, job.InboundEventId })
            .HasPrincipalKey(inbound => new { inbound.AccountId, inbound.Id })
            .OnDelete(DeleteBehavior.Restrict);
    }
}
