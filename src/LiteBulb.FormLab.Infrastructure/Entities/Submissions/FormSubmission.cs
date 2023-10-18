using System.ComponentModel.DataAnnotations.Schema;

namespace LiteBulb.FormLab.Infrastructure.Entities.Submissions;
public class FormSubmission : Entity
{
    [Column(Order = 1)]
    public string Name { get; set; } = string.Empty;

    [Column(Order = 2)]
    public string Description { get; set; } = string.Empty;

    [Column(Order = 3)]
    public virtual IReadOnlyCollection<FieldSubmission> Fields { get; set; } = null!;
}
