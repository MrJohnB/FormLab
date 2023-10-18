using LiteBulb.FormLab.Domain.Dtos.Metadata;
using LiteBulb.FormLab.Domain.Dtos.Submissions;
using LiteBulb.FormLab.Infrastructure.Mappers.Metadata;
using LiteBulb.FormLab.Infrastructure.Mappers.Submissions;
using LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Metadata;
using LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Submissions;
using LiteBulb.FormLab.Shared.Mappers;
using LiteBulb.FormLab.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Configuration;
public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) { throw new ArgumentNullException(nameof(connectionString)); }

        var serverVersion = ServerVersion.AutoDetect(connectionString);

        // For common usages, see pull request #1233.
        // Default service lifetime is Scoped
        return services.AddDbContext<FormLabDbContext>(
            optionsBuilder => optionsBuilder
                .UseMySql(connectionString, serverVersion, options => options
                    .EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services
            .AddSingleton<IMapper<Entities.Metadata.FormMetadata, FormMetadata>, FormMetadataMapper>()
            .AddSingleton<IMapper<Entities.Metadata.FieldMetadata, FieldMetadata>, FieldMetadataMapper>()
            .AddSingleton<IMapper<Entities.Submissions.FormSubmission, FormSubmission>, FormSubmissionMapper>()
            .AddSingleton<IMapper<Entities.Submissions.FieldSubmission, FieldSubmission>, FieldSubmissionMapper>();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IRepository<FormMetadata, int>, FormMetadataRepository>()
            .AddScoped<IRepository<FormSubmission, int>, FormSubmissionRepository>();
    }
}
