using ChatCraft.Domain.Enums;

namespace ChatCraft.Domain.Models.Account;

public class InstagramCredential
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public InstagramAccount InstagramAccount { get; private set; } = new ();
    public byte[] Ciphertext { get; private set; } = [];
    public TokenKind TokenKind { get; private set; } = new ();
    public DateTimeOffset? ExpiresAtUtc { get; private set; }
    public ECredentialStatus Status { get; private set; }

    public InstagramCredential()
    {
        
    }

    public InstagramCredential(Guid accountId,
        byte[] ciphertext,
        TokenKind tokenKind,
        DateTimeOffset expiresAtUtc,
        ECredentialStatus status)
    {
        Id = Guid.CreateVersion7();
        AccountId = accountId;
        Ciphertext = ciphertext;
        TokenKind = tokenKind;
        ExpiresAtUtc = expiresAtUtc;
        Status = status;
    }


    public bool IsUsableAt(DateTimeOffset nowUtc)
    {
        return Status == ECredentialStatus.Active && ExpiresAtUtc > nowUtc;
    }

    public void Revoke()
    {
        Status = ECredentialStatus.Inactive;
    }
}
