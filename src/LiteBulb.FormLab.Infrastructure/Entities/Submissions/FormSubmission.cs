namespace LiteBulb.FormLab.Infrastructure.Entities.Submissions;
public class FormSubmission : Entity
{
    public virtual IReadOnlyCollection<FieldSubmission> Fields { get; set; } = null!;
}
