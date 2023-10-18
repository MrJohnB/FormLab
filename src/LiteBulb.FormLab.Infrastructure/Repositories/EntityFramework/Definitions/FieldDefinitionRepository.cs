using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Infrastructure.Shared.Repositories.EntityFramework;
using LiteBulb.FormLab.Shared.Mappers;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Definitions;
public class FieldDefinitionRepository : AuditableRepository<Entities.Definitions.FieldDefinition, FieldDefinition, int>
{
    public FieldDefinitionRepository(ILogger<FieldDefinitionRepository> logger, FormLabDbContext dbContext, IMapper<Entities.Definitions.FieldDefinition, FieldDefinition> mapper)
        : base(logger, dbContext, mapper) { }
}   
