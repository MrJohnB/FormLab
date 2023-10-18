namespace LiteBulb.FormLab.Domain.Dtos.Submissions;
public class FormSubmission : Dto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IReadOnlyCollection<FieldSubmission> Fields { get; set; } = null!;
}
