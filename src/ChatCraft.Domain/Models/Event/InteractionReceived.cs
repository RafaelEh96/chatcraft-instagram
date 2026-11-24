namespace ChatCraft.Domain.Models.Event;

public class InteractionReceived : InboundEvent
{
    public string SenderIdsId { get; set; } = string.Empty;
    public string ReplyPayload { get; set; } = string.Empty;
    public string? RelatedMessageId { get; set; }
    public string Text { get; set; } = string.Empty;

    public InteractionReceived(string senderIdsId, string replyPayload, string? relatedMessageId, string text) : base(
    accountId: Guid.Empty,
    eventKey: "interaction_received",
    myProperty: 0,
    receivedAtUtc: DateTimeOffset.UtcNow,
    occurredAtUtc: null)
    {
        SenderIdsId = senderIdsId;
        ReplyPayload = replyPayload;
        RelatedMessageId = relatedMessageId;
        Text = text;
    }
}
