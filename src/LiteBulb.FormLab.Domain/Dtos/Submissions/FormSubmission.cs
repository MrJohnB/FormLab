namespace LiteBulb.FormLab.Domain.Dtos.Submissions;
public class FormSubmission : Dto
{
    public IReadOnlyCollection<FieldSubmission> Fields { get; set; } = null!;
}
