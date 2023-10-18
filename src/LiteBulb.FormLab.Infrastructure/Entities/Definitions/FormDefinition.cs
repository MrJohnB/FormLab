using System.ComponentModel.DataAnnotations.Schema;

namespace LiteBulb.FormLab.Infrastructure.Entities.Definitions;
public class FormDefinition : Entity
{
    [Column(Order = 1)]
    public string Name { get; set; } = string.Empty;

    [Column(Order = 2)]
    public string Description { get; set; } = string.Empty;

    [Column(Order = 3)]
    public virtual IReadOnlyCollection<FieldDefinition> Fields { get; set; } = null!;
}
