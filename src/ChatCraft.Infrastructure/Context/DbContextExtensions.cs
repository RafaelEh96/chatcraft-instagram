using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChatCraft.Infrastructure.Context;

public static class DbContextExtensions
{
    public static IServiceCollection AddChatCraftContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ChatCraftContext>(options =>
            ConfigureDbContext(options, connectionString));
        return services;
    }

    public static DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder options, string connectionString)
    {
        options.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
        return options;
    }
}
