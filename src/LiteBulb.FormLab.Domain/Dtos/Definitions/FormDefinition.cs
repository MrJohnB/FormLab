namespace LiteBulb.FormLab.Domain.Dtos.Definitions;
public class FormDefinition : Dto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IReadOnlyCollection<FieldDefinition> Fields { get; set; } = null!;
}
