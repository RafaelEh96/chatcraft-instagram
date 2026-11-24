namespace ChatCraft.Domain.Models.Event;

public abstract class InboundEvent
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string EventKey { get; set; } = string.Empty;
    public DateTimeOffset ReceivedAtUtc { get; set; }
    public DateTimeOffset? OccurredAtUtc { get; set; }
    public string Payload { get; set; } = string.Empty;

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
