using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChatCraft.Infrastructure.Context;

public class ChatCraftContextFactory : IDesignTimeDbContextFactory<ChatCraftContext>
{
    public ChatCraftContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("CHATCRAFT_DB") ?? "Host=localhost;Port=5432;Database=chatcraft;Username=chatcraft;Password=chatcraft_local_only";

        var optionsBuilder = new DbContextOptionsBuilder<ChatCraftContext>();

        DbContextExtensions.ConfigureDbContext(optionsBuilder, connectionString);

        return new ChatCraftContext(optionsBuilder.Options);
    }
}
