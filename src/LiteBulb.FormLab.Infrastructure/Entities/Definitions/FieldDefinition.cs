using System.ComponentModel.DataAnnotations.Schema;

namespace LiteBulb.FormLab.Infrastructure.Entities.Definitions;
public class FieldDefinition : Entity
{
    [Column(Order = 1)]
    public string Name { get; set; } = string.Empty;

    [Column(Order = 2)]
    public string Description { get; set; } = string.Empty;

    [Column(Order = 3)]
    public string Type { get; set; } = string.Empty;
}
