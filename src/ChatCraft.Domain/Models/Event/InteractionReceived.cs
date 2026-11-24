namespace ChatCraft.Domain.Models.Event;

public class InteractionReceived : InboundEvent
{
    public string SenderIdsId { get; private set; } = string.Empty;
    public string ReplyPayload { get; private set; } = string.Empty;
    public string? RelatedMessageId { get; private set; }
    public string Text { get; private set; } = string.Empty;

    public InteractionReceived()
    {
        
    }

    public InteractionReceived(
        string senderIdsId,
        string replyPayload,
        string? relatedMessageId,
        string text) : base()
    {
        SenderIdsId = senderIdsId;
        ReplyPayload = replyPayload;
        RelatedMessageId = relatedMessageId;
        Text = text;
    }
}
