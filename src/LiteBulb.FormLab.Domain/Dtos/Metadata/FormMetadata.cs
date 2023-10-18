namespace LiteBulb.FormLab.Domain.Dtos.Metadata;
public class FormMetadata : Dto
{
    public IReadOnlyCollection<FieldMetadata> Fields { get; set; } = null!;
}
