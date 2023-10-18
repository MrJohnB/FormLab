using LiteBulb.FormLab.Domain.Dtos.Submissions;
using LiteBulb.FormLab.Infrastructure.Shared.Repositories.EntityFramework;
using LiteBulb.FormLab.Shared.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Infrastructure.Repositories.EntityFramework.Submissions;
public class FormSubmissionRepository : AuditableRepository<Entities.Submissions.FormSubmission, FormSubmission, int>
{
    public FormSubmissionRepository(ILogger<FormSubmissionRepository> logger, FormLabDbContext dbContext, IMapper<Entities.Submissions.FormSubmission, FormSubmission> mapper)
        : base(logger, dbContext, mapper) { }

    public override async Task<IReadOnlyList<FormSubmission>> GetAsync()
    {
        var entities = await DbSet
            .Include(x => x.Fields)
            .ToListAsync();

        return Mapper.ToModel(entities);
    }

    public override async Task<FormSubmission?> GetAsync(int id)
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
