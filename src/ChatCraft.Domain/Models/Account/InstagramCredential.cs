using ChatCraft.Domain.Enums;

namespace ChatCraft.Domain.Models.Account;

public class InstagramCredential
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public InstagramAccount InstagramAccount { get; set; } = new ();
    public byte[] Ciphertext { get; set; } = [];
    public TokenKind TokenKind { get; set; } = new ();
    public DateTimeOffset ExpiresAtUtc { get; set; }
    public ECredentialStatus Status { get; set; }

    public InstagramCredential(Guid accountId,
        InstagramAccount instagramAccount,
        byte[] ciphertext,
        TokenKind tokenKind,
        DateTimeOffset expiresAtUtc,
        ECredentialStatus status)
    {
        Id = Guid.CreateVersion7();
        AccountId = accountId;
        InstagramAccount = instagramAccount;
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
