using ChatCraft.Domain.Models.Account;
using ChatCraft.Domain.Models.Event;
using ChatCraft.Domain.Models.Job;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChatCraft.Infrastructure.Context;

public class ChatCraftContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<InstagramAccount> InstagramAccounts { get; set; }
    public DbSet<InstagramCredential> InstagramCredentials { get; set; }
    public DbSet<InboundEvent> InboundEvents { get; set; }
    public DbSet<QueueJob> QueueJobs { get; set; }
    public DbSet<JobAttempt> JobAttempts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
