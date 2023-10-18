namespace LiteBulb.FormLab.Infrastructure.Entities.Metadata;
public class FormMetadata : Entity
{
    public virtual IReadOnlyCollection<FieldMetadata> Fields { get; set; } = null!;
}
