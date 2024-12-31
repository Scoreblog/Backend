using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using ScoreBlog.Application.DI;
using ScoreBlog.Domain;
using ScoreBlog.Infrastructure.Data;
using ScoreBlog.Infrastructure.DI;

namespace ScoreBlog.Presentation.Common.Api;

internal static class BuilderExtension
{
    public static void AddConfiguration(
        this WebApplicationBuilder builder)
    {
        Configuration.IsDevelopment = builder.Environment.IsDevelopment();
        Configuration.BackendUrl = Environment.GetEnvironmentVariable("BACKEND_URL") ?? string.Empty;
        Configuration.FrontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? string.Empty;
        Configuration.AwsKeyId = Environment.GetEnvironmentVariable("AWS_KEY_ID") ?? string.Empty;
        Configuration.AwsKeySecret = Environment.GetEnvironmentVariable("AWS_KEY_SECRET") ?? string.Empty;
        Configuration.AwsRegion = Environment.GetEnvironmentVariable("AWS_REGION") ?? string.Empty;
        Configuration.BucketImages = Environment.GetEnvironmentVariable("BUCKET_IMAGES") ?? string.Empty;
        Configuration.SmtpUser = Environment.GetEnvironmentVariable("SMTP_USER") ?? string.Empty;
        Configuration.SmtpPort = int.TryParse(Environment.GetEnvironmentVariable("SMTP_PORT"), out var smtpPort) ? smtpPort : 587;
        Configuration.SmtpPass = Environment.GetEnvironmentVariable("SMTP_PASS") ?? string.Empty;
        Configuration.BucketVideos = Environment.GetEnvironmentVariable("BUCKET_VIDEOS") ?? string.Empty;
        Configuration.DurationUrlTempVideos = 24;
        Configuration.DurationUrlTempImage = 24;
        Configuration.Database = Environment.GetEnvironmentVariable("DATABASE") ?? string.Empty;
        Configuration.UserNameDatabase = Environment.GetEnvironmentVariable("USERNAME_DATABASE") ?? string.Empty;
        Configuration.HostDatabase = Environment.GetEnvironmentVariable("HOST_DATABASE") ?? string.Empty;
        Configuration.PassWordDatabase = Environment.GetEnvironmentVariable("PASSWORD_DATABASE") ?? string.Empty;
        Configuration.PortDatabase = int.TryParse(Environment.GetEnvironmentVariable("PORT_DATABASE"), out var portdatabase) ? portdatabase : 5432;
        builder.Services.AddControllers(options =>
    {
        options.Filters.Add(new ProducesAttribute("application/json"));
        options.ReturnHttpNotAcceptable = true;
    })
    .AddNewtonsoftJson();
        builder.Services.AddEndpointsApiExplorer();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
      //IMPLEMENTAR OAUTH 2.0 ou JWT.
        builder.Services.AddAuthorization();
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<ScoreBlogDbContext>(
                x => { x.UseNpgsql(StringConnection.BuildConnectionString()); });
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                Configuration.CorsPolicyName,
                policy => policy
                    .WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            options.KnownProxies.Clear();
        });

        builder.Services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 1024 * 1024 * 500;
        });
        builder.Services.Configure<KestrelServerOptions>(options =>
        {
            options.Limits.MaxRequestBodySize = 1024 * 1024 * 500;
        });
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddLogging(logging =>
        {
            logging.AddConsole();
            logging.AddDebug();
        });
        builder.Services.AplicationServices();
        builder.Services.ConfigureInfraServices(builder.Configuration);
    }
}