using System.ComponentModel.DataAnnotations.Schema;
using LiteBulb.FormLab.Shared.Entities;

namespace LiteBulb.FormLab.Infrastructure.Entities;
public abstract class Entity : Auditable, IEntity<int>
{
    [Column(Order = 0)]
    public int Id { get; set; }
}
