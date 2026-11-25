using ChatCraft.Domain.Models.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatCraft.Infrastructure.Mapping;

public class JobAttemptMap : IEntityTypeConfiguration<JobAttempt>
{
    public void Configure(EntityTypeBuilder<JobAttempt> builder)
    {
        builder.ToTable("job_attempts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
            .IsRequired();  

        builder.Property(x => x.StartedAtUtc)
            .IsRequired();

        builder.Property(x => x.FinishedAtUtc)
            .IsRequired(false);

        builder.Property(x => x.Outcome)
            .IsRequired(false)
            .HasColumnType("smallint");

        builder.Property(x => x.ProviderMessageId)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.HasOne(x => x.QueueJob)
            .WithMany()
            .HasForeignKey(x => x.JobId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
