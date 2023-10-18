namespace LiteBulb.FormLab.Infrastructure.Entities.Definitions;
public class FieldDefinition : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
