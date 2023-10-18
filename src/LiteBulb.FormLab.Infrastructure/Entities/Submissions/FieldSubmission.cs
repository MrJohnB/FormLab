namespace LiteBulb.FormLab.Infrastructure.Entities.Submissions;
public class FieldSubmission : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
