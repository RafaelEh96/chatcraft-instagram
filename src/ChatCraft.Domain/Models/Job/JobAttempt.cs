using ChatCraft.Domain.Enums;

namespace ChatCraft.Domain.Models.Job;

public class JobAttempt
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public DateTimeOffset StartedAtUtc { get; set; }
    public DateTimeOffset FinishedAtUtc { get; set; }
    public EAttemptOutcome? Outcome { get; set; }
    public string ProviderMessageId { get; set; } = string.Empty;

    public JobAttempt(int number,
        DateTimeOffset startedAtUtc,
        DateTimeOffset finishedAtUtc,
        EAttemptOutcome? outcome,
        string providerMessageId)
    {
        Number = number;
        StartedAtUtc = startedAtUtc;
        FinishedAtUtc = finishedAtUtc;
        Outcome = outcome;
        ProviderMessageId = providerMessageId;
    }

    public void Complete(EAttemptOutcome outcome, DateTimeOffset atUtc)
    {
        Outcome = outcome;
        FinishedAtUtc = atUtc;
    }
}
