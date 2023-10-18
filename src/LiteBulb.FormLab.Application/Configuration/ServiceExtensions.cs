using LiteBulb.FormLab.Application.Services.Definitions;
using LiteBulb.FormLab.Application.Services.Submissions;
using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Domain.Dtos.Submissions;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.Extensions.DependencyInjection;

namespace LiteBulb.FormLab.Application.Configuration;
public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IService<FormDefinition, int>, FormDefinitionService>()
            .AddScoped<IService<FieldDefinition, int>, FieldDefinitionService>()
            .AddScoped<IService<FormSubmission, int>, FormSubmissionService>();
    }
}
