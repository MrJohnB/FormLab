using LiteBulb.FormLab.Domain.Dtos.Metadata;
using LiteBulb.FormLab.Infrastructure.Shared.Repositories.EntityFramework;
using LiteBulb.FormLab.Shared.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Metadata;
public class FormMetadataRepository : AuditableRepository<Entities.Metadata.FormMetadata, FormMetadata, int>
{
    public FormMetadataRepository(ILogger<FormMetadataRepository> logger, FormLabDbContext dbContext, IMapper<Entities.Metadata.FormMetadata, FormMetadata> mapper)
        : base(logger, dbContext, mapper) { }

    public override async Task<IReadOnlyList<FormMetadata>> GetAsync()
    {
        var entities = await DbSet
            .Include(x => x.Fields)
            .ToListAsync();

        return Mapper.ToModel(entities);
    }

    public override async Task<FormMetadata?> GetAsync(int id)
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
