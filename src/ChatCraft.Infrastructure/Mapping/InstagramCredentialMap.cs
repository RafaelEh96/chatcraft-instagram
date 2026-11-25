using ChatCraft.Domain.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatCraft.Infrastructure.Mapping;

public class InstagramCredentialMap : IEntityTypeConfiguration<InstagramCredential>
{
    public void Configure(EntityTypeBuilder<InstagramCredential> builder)
    {
        builder.ToTable("instagram_credentials");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Ciphertext)
            .IsRequired();

        builder.Property(x => x.ExpiresAtUtc)
            .IsRequired(false);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnType("smallint");

        builder.Property(x => x.TokenKind)
            .IsRequired()
            .HasColumnType("smallint");

        builder.HasOne(x => x.InstagramAccount)
            .WithMany(x => x.Credentials)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
