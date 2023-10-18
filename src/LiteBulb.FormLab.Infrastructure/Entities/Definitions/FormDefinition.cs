namespace LiteBulb.FormLab.Infrastructure.Entities.Definitions;
public class FormDefinition : Entity
{
    public virtual IReadOnlyCollection<FieldDefinition> Fields { get; set; } = null!;
}
