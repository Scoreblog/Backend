using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ScoreBlog.Domain.Entities;

namespace ScoreBlog.Infrastructure.Data;

internal class ScoreBlogDbContext(DbContextOptions<ScoreBlogDbContext> options) : DbContext
{
    public DbSet<User> Users { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}