using LiteBulb.FormLab.Shared.Entities;

namespace LiteBulb.FormLab.Infrastructure.Entities;
public abstract class Entity : Auditable, IEntity<int>
{
    public int Id { get; set; }
}
