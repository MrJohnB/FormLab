namespace LiteBulb.FormLab.Domain.Dtos.Definitions;
public class FormDefinition : Dto
{
    public IReadOnlyCollection<FieldDefinition> Fields { get; set; } = null!;
}
