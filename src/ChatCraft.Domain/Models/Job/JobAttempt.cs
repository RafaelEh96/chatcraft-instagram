using ChatCraft.Domain.Enums;

namespace ChatCraft.Domain.Models.Job;

public class JobAttempt
{
    public Guid Id { get; set; }
    public Guid JobId { get; set; }
    public QueueJob QueueJob { get; set; } = new();
    public int Number { get; set; }
    public DateTimeOffset StartedAtUtc { get; set; }
    public DateTimeOffset? FinishedAtUtc { get; set; }
    public EAttemptOutcome? Outcome { get; set; }
    public string? ProviderMessageId { get; set; }

    public JobAttempt()
    {
        
    }

    public JobAttempt(int number,
        DateTimeOffset startedAtUtc,
        DateTimeOffset finishedAtUtc,
        EAttemptOutcome? outcome,
        string providerMessageId,
        Guid jobId)
    {
        Number = number;
        StartedAtUtc = startedAtUtc;
        FinishedAtUtc = finishedAtUtc;
        Outcome = outcome;
        ProviderMessageId = providerMessageId;
        JobId = jobId;
    }

    public void Complete(EAttemptOutcome outcome, DateTimeOffset atUtc)
    {
        Outcome = outcome;
        FinishedAtUtc = atUtc;
    }
}
