using ChatCraft.Domain.Enums;

namespace ChatCraft.Domain.Models.Account;

public class InstagramAccount
{
    public Guid Id { get; private set; }
    public string MetaAccountId { get; private set; } = string.Empty;
    public string BusinessId { get; private set; } = string.Empty;
    public EConnectionStatus Status { get; private set; }
    public long Version { get; private set; }
    public Guid? ActiveCredentialId { get; private set; }
    public IEnumerable<InstagramCredential> Credentials { get; private set; } = [];

    public InstagramAccount()
    {

    }

    public InstagramAccount(
        string metaAccountId,
        string businessId,
        EConnectionStatus status,
        long version,
        Guid? activeCredentialId,
        IEnumerable<InstagramCredential> credentials)
    {
        Id = Guid.CreateVersion7();
        MetaAccountId = metaAccountId;
        BusinessId = businessId;
        Status = status;
        Version = version;
        ActiveCredentialId = activeCredentialId;
        Credentials = credentials;
    }

    public void MarkOperational(Guid credentalId)
    {
        Status = EConnectionStatus.Operational;
        ActiveCredentialId = credentalId;
    }

    public void RequireReconnect()
    {
        Status = EConnectionStatus.Pending;
        ActiveCredentialId = null;
    }
}
