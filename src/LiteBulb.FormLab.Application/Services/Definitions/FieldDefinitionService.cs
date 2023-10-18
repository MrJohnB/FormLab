using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Shared.Repositories;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Application.Services.Definitions;
public class FieldDefinitionService : Service<FieldDefinition, int>
{
    public FieldDefinitionService(ILogger<FieldDefinitionService> logger, IRepository<FieldDefinition, int> fieldDefinitionRepository)
        : base(logger, fieldDefinitionRepository) { }
}
