namespace ChatCraft.Domain.Models.Event;

public class CommentReceived : InboundEvent
{
    public string CommentId { get; set; } = string.Empty;
    public string MediaId { get; set; } = string.Empty;
    public string? AuthorIgsId { get; set; }
    public string Text { get; set; } = string.Empty;

    public CommentReceived(string commentId, string mediaId, string? authorIgsId, string text) : base(
       accountId: Guid.Empty,
       eventKey: "comment_received",
       myProperty: 0,
       receivedAtUtc: DateTimeOffset.UtcNow,
       occurredAtUtc: null)
    {
        CommentId = commentId;
        MediaId = mediaId;
        AuthorIgsId = authorIgsId;
        Text = text;
    }
}
