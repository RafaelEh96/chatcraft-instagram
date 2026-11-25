using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatCraft.Infrastructure.Migrations;

/// <inheritdoc />
public partial class _20261125190336_v1 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "inbox_events",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                account_id = table.Column<Guid>(type: "uuid", nullable: false),
                event_key = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                received_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                occurred_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                payload = table.Column<string>(type: "jsonb", nullable: false),
                event_type = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                comment_id = table.Column<string>(type: "text", nullable: true),
                media_id = table.Column<string>(type: "text", nullable: true),
                author_igs_id = table.Column<string>(type: "text", nullable: true),
                text = table.Column<string>(type: "text", nullable: true),
                sender_ids_id = table.Column<string>(type: "text", nullable: true),
                reply_payload = table.Column<string>(type: "text", nullable: true),
                related_message_id = table.Column<string>(type: "text", nullable: true),
                interaction_received_text = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_inbox_events", x => x.id);
                table.UniqueConstraint("ak_inbox_events_account_id_id", x => new { x.account_id, x.id });
            });

        migrationBuilder.CreateTable(
            name: "instagram_accounts",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                meta_account_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                business_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                status = table.Column<short>(type: "smallint", nullable: false),
                version = table.Column<long>(type: "bigint", nullable: false),
                active_credential_id = table.Column<Guid>(type: "uuid", maxLength: 255, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_instagram_accounts", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "instagram_credentials",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                account_id = table.Column<Guid>(type: "uuid", nullable: false),
                ciphertext = table.Column<byte[]>(type: "bytea", nullable: false),
                token_kind = table.Column<short>(type: "smallint", nullable: false),
                expires_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                status = table.Column<short>(type: "smallint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_instagram_credentials", x => x.id);
                table.ForeignKey(
                    name: "fk_instagram_credentials_instagram_accounts_account_id",
                    column: x => x.account_id,
                    principalTable: "instagram_accounts",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "queue_jobs",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                account_id = table.Column<Guid>(type: "uuid", nullable: false),
                action_key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                type = table.Column<short>(type: "smallint", nullable: false),
                status = table.Column<short>(type: "smallint", nullable: false),
                due_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                lease_until_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                lease_version = table.Column<long>(type: "bigint", nullable: false),
                attempt_count = table.Column<int>(type: "integer", nullable: false),
                inbound_event_id = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_queue_jobs", x => x.id);
                table.ForeignKey(
                    name: "fk_queue_jobs_inbox_events_account_id_inbound_event_id",
                    columns: x => new { x.account_id, x.inbound_event_id },
                    principalTable: "inbox_events",
                    principalColumns: new[] { "account_id", "id" },
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "fk_queue_jobs_instagram_accounts_account_id",
                    column: x => x.account_id,
                    principalTable: "instagram_accounts",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "job_attempts",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                job_id = table.Column<Guid>(type: "uuid", nullable: false),
                number = table.Column<int>(type: "integer", nullable: false),
                started_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                finished_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                outcome = table.Column<short>(type: "smallint", nullable: true),
                provider_message_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_job_attempts", x => x.id);
                table.ForeignKey(
                    name: "fk_job_attempts_queue_jobs_job_id",
                    column: x => x.job_id,
                    principalTable: "queue_jobs",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "ix_inbox_events_account_id_event_key",
            table: "inbox_events",
            columns: new[] { "account_id", "event_key" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_instagram_accounts_meta_account_id",
            table: "instagram_accounts",
            column: "meta_account_id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_instagram_credentials_account_id",
            table: "instagram_credentials",
            column: "account_id");

        migrationBuilder.CreateIndex(
            name: "ix_job_attempts_job_id",
            table: "job_attempts",
            column: "job_id");

        migrationBuilder.CreateIndex(
            name: "ix_queue_jobs_account_id_inbound_event_id",
            table: "queue_jobs",
            columns: new[] { "account_id", "inbound_event_id" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "instagram_credentials");

        migrationBuilder.DropTable(
            name: "job_attempts");

        migrationBuilder.DropTable(
            name: "queue_jobs");

        migrationBuilder.DropTable(
            name: "inbox_events");

        migrationBuilder.DropTable(
            name: "instagram_accounts");
    }
}
