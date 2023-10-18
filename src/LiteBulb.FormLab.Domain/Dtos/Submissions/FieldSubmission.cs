namespace LiteBulb.FormLab.Domain.Dtos.Submissions;
public class FieldSubmission : Dto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
