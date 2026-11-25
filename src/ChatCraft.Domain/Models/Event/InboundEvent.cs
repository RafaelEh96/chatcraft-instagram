namespace ChatCraft.Domain.Models.Event;

public abstract class InboundEvent
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public string EventKey { get; private set; } = string.Empty;
    public DateTimeOffset ReceivedAtUtc { get; private set; }
    public DateTimeOffset? OccurredAtUtc { get; private set; }
    public string Payload { get; private set; } = string.Empty;

    protected InboundEvent()
    {

    }

    protected InboundEvent(
        Guid accountId,
        string eventKey,
        DateTimeOffset receivedAtUtc,
        DateTimeOffset? occurredAtUtc,
        string payload)
    {
        Id = Guid.CreateVersion7();
        AccountId = accountId;
        EventKey = eventKey;
        ReceivedAtUtc = receivedAtUtc;
        OccurredAtUtc = occurredAtUtc;
        Payload = payload;
    }
}
