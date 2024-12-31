using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScoreBlog.Domain.Interfaces;
using ScoreBlog.Infrastructure.Repositories;

namespace ScoreBlog.Infrastructure.DI;

internal static class ServicesExtensions
{
    public static void ConfigureInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IDbCommit, DbCommit>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}