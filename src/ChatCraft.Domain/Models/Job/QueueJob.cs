using ChatCraft.Domain.Enums;

namespace ChatCraft.Domain.Models.Job;

public class QueueJob
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public string ActionKey { get; private set; } = string.Empty;
    public EJobType Type { get; private set; }
    public EJobStatus Status { get; private set; }
    public DateTimeOffset DueAtUtc { get; private set; }
    public DateTimeOffset LeaseUntilUtc { get; private set; }
    public long LeaseVersion { get; private set; }
    public int AttemptCount { get; private set; }

    public QueueJob()
    {
        
    }

    public QueueJob(
        Guid accountId,
        string actionKey,
        EJobType type,
        EJobStatus status,
        DateTimeOffset dueAtUtc,
        DateTimeOffset leaseUntilUtc,
        long leaseVersion,
        int attemptCount)
    {
        Id = Guid.CreateVersion7();
        AccountId = accountId;
        ActionKey = actionKey;
        Type = type;
        Status = status;
        DueAtUtc = dueAtUtc;
        LeaseUntilUtc = leaseUntilUtc;
        LeaseVersion = leaseVersion;
        AttemptCount = attemptCount;
    }

    public void BeginSend(long leaseVersion)
    {
        Status = EJobStatus.InProgress;
        LeaseUntilUtc = DateTimeOffset.UtcNow.AddHours(1);
        LeaseVersion = leaseVersion;
    }

    public void Reschedule(DateTimeOffset dueAtUtc)
    {
        Status = EJobStatus.Queued;
        DueAtUtc = dueAtUtc;
        LeaseUntilUtc = DateTimeOffset.MinValue;
        LeaseVersion = 0;
        AttemptCount++;
    }

    public void MarkUncertain()
    {
        Status = EJobStatus.Uncertain;
        LeaseUntilUtc = DateTimeOffset.MinValue;
        LeaseVersion = 0;
    }
}
