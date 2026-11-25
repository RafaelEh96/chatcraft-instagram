using ChatCraft.Domain.Enums;
using ChatCraft.Domain.Models.Event;

namespace ChatCraft.Domain.Models.Job;

public class QueueJob
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public string ActionKey { get; private set; } = string.Empty;
    public EJobType Type { get; private set; }
    public EJobStatus Status { get; private set; }
    public DateTimeOffset DueAtUtc { get; private set; }
    public DateTimeOffset? LeaseUntilUtc { get; private set; }
    public long LeaseVersion { get; private set; }
    public int AttemptCount { get; private set; }
    public Guid InboundEventId { get; set; }
    public InboundEvent InboundEvent { get; set; }

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
        int attemptCount,
        Guid inboundEventId)
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
        InboundEventId = inboundEventId;
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
        LeaseVersion++;
        AttemptCount++;
    }

    public void MarkUncertain()
    {
        Status = EJobStatus.Uncertain;
        LeaseUntilUtc = DateTimeOffset.MinValue;
        LeaseVersion++;
    }
}
