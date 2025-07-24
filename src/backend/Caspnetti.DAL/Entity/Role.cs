using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("Roles")]
public class Role: IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
