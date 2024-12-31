using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;
using ScoreBlog.Domain;

namespace ScoreBlog.Infrastructure.Data;

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ScoreBlogDbContext>
{
    public ScoreBlogDbContext CreateDbContext(string[] args)
    {
        try
        {
            var connectionString = args.FirstOrDefault() ?? StringConnection.BuildConnectionString();
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("A connection string must be provided.");

            var builder = new DbContextOptionsBuilder<ScoreBlogDbContext>();
            builder.UseNpgsql(connectionString);
            var context = new ScoreBlogDbContext(builder.Options);
            return context;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}

internal static class StringConnection
{
    public static string BuildConnectionString()
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = Configuration.HostDatabase, Port = Configuration.PortDatabase, Database = Configuration.Database,
            Username = Configuration.UserNameDatabase,
            Password = Configuration.PassWordDatabase
        };
        return builder.ConnectionString;
    }
}