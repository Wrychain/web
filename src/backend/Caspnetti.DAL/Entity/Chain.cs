// Discord server datatype equivalent

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Caspnetti.DAL.Entity;

[Table("Chains")]
[Index(nameof(Name), IsUnique = true)]
public class Chain: IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual required User Creator { get; set; }
    public virtual required ICollection<User> Users { get; set; }
    public virtual ICollection<Mesh>? DefaultMeshes { get; set; }
    public virtual ICollection<Mesh>? UserMeshes { get; set; }
    public virtual ICollection<Thread>? GlobalThreads { get; set; }

    public Chain()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
