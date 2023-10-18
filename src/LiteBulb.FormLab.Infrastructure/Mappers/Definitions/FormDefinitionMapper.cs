using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Shared.Mappers;

namespace LiteBulb.FormLab.Infrastructure.Mappers.Definition;
public class FormDefinitionMapper : IMapper<Entities.Definitions.FormDefinition, FormDefinition>
{
    private readonly IMapper<Entities.Definitions.FieldDefinition, FieldDefinition> _fieldDefinitionMapper;

    public FormDefinitionMapper(IMapper<Entities.Definitions.FieldDefinition, FieldDefinition> fieldDefinitionMapper)
    {
        _fieldDefinitionMapper = fieldDefinitionMapper ?? throw new ArgumentNullException(nameof(fieldDefinitionMapper));
    }

    public FormDefinition ToModel(Entities.Definitions.FormDefinition entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        return new FormDefinition()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Fields = _fieldDefinitionMapper.ToModel(entity.Fields)
        };
    }

    public IReadOnlyList<FormDefinition> ToModel(IEnumerable<Entities.Definitions.FormDefinition> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));

        var models = new List<FormDefinition>();

        // TODO: use LINQ Select() instead
        foreach (var entity in entities)
        {
            models.Add(ToModel(entity));
        }

        return models;
    }

    public Entities.Definitions.FormDefinition ToEntity(FormDefinition model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));

        return new Entities.Definitions.FormDefinition()
        {
            Id = model.Id ??= 0,
            Name = model.Name,
            Description = model.Description,
            Fields = _fieldDefinitionMapper.ToEntity(model.Fields)
            // Note: ignore Created and LastModified
        };
    }

    public IReadOnlyList<Entities.Definitions.FormDefinition> ToEntity(IEnumerable<FormDefinition> models)
    {
        ArgumentNullException.ThrowIfNull(models, nameof(models));

        var entities = new List<Entities.Definitions.FormDefinition>();

        foreach (var model in models)
        {
            entities.Add(ToEntity(model));
        }

        return entities;
    }
}
