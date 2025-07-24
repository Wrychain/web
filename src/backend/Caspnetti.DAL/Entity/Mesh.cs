// A logical grouping of threads

using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("Meshes")]
public class Mesh: IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual required ICollection<ThreadOrdering> ThreadOrderings { get; set; }

    public Mesh()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
