namespace ChatCraft.Domain.Models.Event;

public class CommentReceived : InboundEvent
{
    public string CommentId { get; private set; } = string.Empty;
    public string MediaId { get; private set; } = string.Empty;
    public string? AuthorIgsId { get; private set; }
    public string Text { get; private set; } = string.Empty;

    public CommentReceived()
    {
        
    }

    public CommentReceived(
        string commentId,
        string mediaId,
        string? authorIgsId,
        string text) : base()
    {
        CommentId = commentId;
        MediaId = mediaId;
        AuthorIgsId = authorIgsId;
        Text = text;
    }
}
