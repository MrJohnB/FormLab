using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Infrastructure.Shared.Repositories.EntityFramework;
using LiteBulb.FormLab.Shared.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Definition;
public class FormDefinitionRepository : AuditableRepository<Entities.Definitions.FormDefinition, FormDefinition, int>
{
    public FormDefinitionRepository(ILogger<FormDefinitionRepository> logger, FormLabDbContext dbContext, IMapper<Entities.Definitions.FormDefinition, FormDefinition> mapper)
        : base(logger, dbContext, mapper) { }

    public override async Task<IReadOnlyList<FormDefinition>> GetAsync()
    {
        var entities = await DbSet
            .Include(x => x.Fields)
            .ToListAsync();

        return Mapper.ToModel(entities);
    }

    public override async Task<FormDefinition?> GetAsync(int id)
    {
        var entity = await DbSet
            .Include(x => x.Fields)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
        {
            return null;
        }

        return Mapper.ToModel(entity);
    }
}   
