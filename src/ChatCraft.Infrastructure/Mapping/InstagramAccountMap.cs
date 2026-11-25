using ChatCraft.Domain.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatCraft.Infrastructure.Mapping;

public class InstagramAccountMap : IEntityTypeConfiguration<InstagramAccount>
{
    public void Configure(EntityTypeBuilder<InstagramAccount> builder)
    {
        builder.ToTable("instagram_accounts");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.MetaAccountId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.BusinessId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnType("smallint");

        builder.Property(x => x.Version)
            .IsRequired();

        builder.Property(x => x.ActiveCredentialId)
            .IsRequired(false)
            .HasMaxLength(255);

        builder.HasIndex(x => x.MetaAccountId).IsUnique();
    }
}
