using LiteBulb.FormLab.Domain.Dtos.Submissions;
using LiteBulb.FormLab.Shared.Mappers;

namespace LiteBulb.FormLab.Infrastructure.Mappers.Submissions;
public class FieldSubmissionMapper : IMapper<Entities.Submissions.FieldSubmission, FieldSubmission>
{
    public FieldSubmissionMapper() { }

    public FieldSubmission ToModel(Entities.Submissions.FieldSubmission entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        return new FieldSubmission()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Type = entity.Type,
            Value = entity.Value
        };
    }

    public IReadOnlyList<FieldSubmission> ToModel(IEnumerable<Entities.Submissions.FieldSubmission> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));

        var models = new List<FieldSubmission>();

        // TODO: use LINQ Select() instead
        foreach (var entity in entities)
        {
            models.Add(ToModel(entity));
        }

        return models;
    }

    public Entities.Submissions.FieldSubmission ToEntity(FieldSubmission model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));

        return new Entities.Submissions.FieldSubmission()
        {
            Id = model.Id ??= 0,
            Name = model.Name,
            Description = model.Description,
            Type = model.Type,
            Value = model.Value
            // Note: ignore Created and LastModified
        };
    }

    public IReadOnlyList<Entities.Submissions.FieldSubmission> ToEntity(IEnumerable<FieldSubmission> models)
    {
        ArgumentNullException.ThrowIfNull(models, nameof(models));

        var entities = new List<Entities.Submissions.FieldSubmission>();

        foreach (var model in models)
        {
            entities.Add(ToEntity(model));
        }

        return entities;
    }
}
