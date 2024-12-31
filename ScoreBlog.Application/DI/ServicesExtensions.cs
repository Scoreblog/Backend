using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ScoreBlog.Application.DI;

internal static class ServicesExtensions
{
    public static void AplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}