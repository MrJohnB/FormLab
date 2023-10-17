namespace LiteBulb.FormLab.Shared.Entities;
public interface IEntity<TId>
{
    TId Id { get; set; }
}
