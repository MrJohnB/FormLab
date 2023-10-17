namespace LiteBulb.FormLab.Domain.Dtos.Submissions;
public class FormSubmission
{
    public IReadOnlyCollection<FieldSubmission> Fields { get; set; } = null!;
}
