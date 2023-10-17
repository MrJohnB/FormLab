using LiteBulb.FormLab.Application.Services.Data;
using LiteBulb.FormLab.Domain.Dtos.Metadata;
using LiteBulb.FormLab.Domain.Dtos.Submissions;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.Extensions.DependencyInjection;

namespace LiteBulb.FormLab.Application.Configuration;
public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IService<FormMetadata, int>, FormMetadataService>()
            .AddScoped<IService<FormSubmission, int>, FormSubmissionService>();
    }
}
