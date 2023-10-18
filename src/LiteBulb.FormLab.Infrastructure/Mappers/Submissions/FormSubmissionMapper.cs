using LiteBulb.FormLab.Domain.Dtos.Submissions;
using LiteBulb.FormLab.Shared.Mappers;

namespace LiteBulb.FormLab.Infrastructure.Mappers.Submissions;
public class FormSubmissionMapper : IMapper<Entities.Submissions.FormSubmission, FormSubmission>
{
    private readonly IMapper<Entities.Submissions.FieldSubmission, FieldSubmission> _fieldSubmissionMapper;

    public FormSubmissionMapper(IMapper<Entities.Submissions.FieldSubmission, FieldSubmission> fieldSubmissionMapper)
    {
        _fieldSubmissionMapper = fieldSubmissionMapper ?? throw new ArgumentNullException(nameof(fieldSubmissionMapper));
    }

    public FormSubmission ToModel(Entities.Submissions.FormSubmission entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        return new FormSubmission()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Fields = _fieldSubmissionMapper.ToModel(entity.Fields)
        };
    }

    public IReadOnlyList<FormSubmission> ToModel(IEnumerable<Entities.Submissions.FormSubmission> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));

        var models = new List<FormSubmission>();

        // TODO: use LINQ Select() instead
        foreach (var entity in entities)
        {
            models.Add(ToModel(entity));
        }

        return models;
    }

    public Entities.Submissions.FormSubmission ToEntity(FormSubmission model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));

        return new Entities.Submissions.FormSubmission()
        {
            Id = model.Id ??= 0,
            Name = model.Name,
            Description = model.Description,
            Fields = _fieldSubmissionMapper.ToEntity(model.Fields)
            // Note: ignore Created and LastModified
        };
    }

    public IReadOnlyList<Entities.Submissions.FormSubmission> ToEntity(IEnumerable<FormSubmission> models)
    {
        ArgumentNullException.ThrowIfNull(models, nameof(models));

        var entities = new List<Entities.Submissions.FormSubmission>();

        foreach (var model in models)
        {
            entities.Add(ToEntity(model));
        }

        return entities;
    }
}
