using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Shared.Repositories;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Application.Services.Data;
public class FormDefinitionService : Service<FormDefinition, int>
{
    public FormDefinitionService(ILogger<FormDefinitionService> logger, IRepository<FormDefinition, int> formDefinitionRepository)
        : base(logger, formDefinitionRepository) { }
}
