using LiteBulb.FormLab.Domain.Dtos.Metadata;
using LiteBulb.FormLab.Shared.Repositories;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Application.Services.Data;
public class FormMetadataService : Service<FormMetadata, int>
{
    public FormMetadataService(ILogger<FormMetadataService> logger, IRepository<FormMetadata, int> formMetadataRepository)
        : base(logger, formMetadataRepository) { }
}
