using LiteBulb.FormLab.Domain.Dtos.Metadata;
using LiteBulb.FormLab.Shared.Mappers;

namespace LiteBulb.FormLab.Infrastructure.Mappers.Metadata;
public class FieldMetadataMapper : IMapper<Entities.Metadata.FieldMetadata, FieldMetadata>
{
    public FieldMetadataMapper() { }

    public FieldMetadata ToModel(Entities.Metadata.FieldMetadata entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        return new FieldMetadata()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Type = entity.Type
        };
    }

    public IReadOnlyList<FieldMetadata> ToModel(IEnumerable<Entities.Metadata.FieldMetadata> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));

        var models = new List<FieldMetadata>();

        // TODO: use LINQ Select() instead
        foreach (var entity in entities)
        {
            models.Add(ToModel(entity));
        }

        return models;
    }

    public Entities.Metadata.FieldMetadata ToEntity(FieldMetadata model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));

        return new Entities.Metadata.FieldMetadata()
        {
            Id = model.Id ??= 0,
            Name = model.Name,
            Description = model.Description,
            Type = model.Type
            // Note: ignore Created and LastModified
        };
    }

    public IReadOnlyList<Entities.Metadata.FieldMetadata> ToEntity(IEnumerable<FieldMetadata> models)
    {
        ArgumentNullException.ThrowIfNull(models, nameof(models));

        var entities = new List<Entities.Metadata.FieldMetadata>();

        foreach(var model in models)
        {
            entities.Add(ToEntity(model));
        }

        return entities;
    }
}
