using LiteBulb.FormLab.Domain.Dtos.Metadata;
using LiteBulb.FormLab.Shared.Mappers;

namespace LiteBulb.FormLab.Infrastructure.Mappers.Metadata;
public class FormMetadataMapper : IMapper<Entities.Metadata.FormMetadata, FormMetadata>
{
    private readonly IMapper<Entities.Metadata.FieldMetadata, FieldMetadata> _fieldMetadataMapper;

    public FormMetadataMapper(IMapper<Entities.Metadata.FieldMetadata, FieldMetadata> fieldMetadataMapper)
    {
        _fieldMetadataMapper = fieldMetadataMapper ?? throw new ArgumentNullException(nameof(fieldMetadataMapper));
    }

    public FormMetadata ToModel(Entities.Metadata.FormMetadata entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        return new FormMetadata()
        {
            Id = entity.Id,
            Fields = _fieldMetadataMapper.ToModel(entity.Fields)
        };
    }

    public IReadOnlyList<FormMetadata> ToModel(IEnumerable<Entities.Metadata.FormMetadata> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, nameof(entities));

        var models = new List<FormMetadata>();

        // TODO: use LINQ Select() instead
        foreach (var entity in entities)
        {
            models.Add(ToModel(entity));
        }

        return models;
    }

    public Entities.Metadata.FormMetadata ToEntity(FormMetadata model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));

        return new Entities.Metadata.FormMetadata()
        {
            Id = model.Id ??= 0,
            Fields = _fieldMetadataMapper.ToEntity(model.Fields)
            // Note: ignore Created and LastModified
        };
    }

    public IReadOnlyList<Entities.Metadata.FormMetadata> ToEntity(IEnumerable<FormMetadata> models)
    {
        ArgumentNullException.ThrowIfNull(models, nameof(models));

        var entities = new List<Entities.Metadata.FormMetadata>();

        foreach (var model in models)
        {
            entities.Add(ToEntity(model));
        }

        return entities;
    }
}
