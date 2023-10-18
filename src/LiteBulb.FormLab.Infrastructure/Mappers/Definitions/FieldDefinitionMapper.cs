using LiteBulb.FormLab.Domain.Dtos.Definitions;
using LiteBulb.FormLab.Shared.Mappers;

namespace LiteBulb.FormLab.Infrastructure.Mappers.Definition;
public class FieldDefinitionMapper : IMapper<Entities.Definitions.FieldDefinition, FieldDefinition>
{
    public FieldDefinitionMapper() { }

    public FieldDefinition ToModel(Entities.Definitions.FieldDefinition entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        return new FieldDefinition()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Type = entity.Type
        };
    }

    public IReadOnlyList<FieldDefinition> ToModel(IEnumerable<Entities.Definitions.FieldDefinition> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));

        var models = new List<FieldDefinition>();

        // TODO: use LINQ Select() instead
        foreach (var entity in entities)
        {
            models.Add(ToModel(entity));
        }

        return models;
    }

    public Entities.Definitions.FieldDefinition ToEntity(FieldDefinition model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));

        return new Entities.Definitions.FieldDefinition()
        {
            Id = model.Id ??= 0,
            Name = model.Name,
            Description = model.Description,
            Type = model.Type
            // Note: ignore Created and LastModified
        };
    }

    public IReadOnlyList<Entities.Definitions.FieldDefinition> ToEntity(IEnumerable<FieldDefinition> models)
    {
        ArgumentNullException.ThrowIfNull(models, nameof(models));

        var entities = new List<Entities.Definitions.FieldDefinition>();

        foreach(var model in models)
        {
            entities.Add(ToEntity(model));
        }

        return entities;
    }
}
