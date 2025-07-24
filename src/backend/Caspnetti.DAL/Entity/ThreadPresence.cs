using System.ComponentModel.DataAnnotations.Schema;
using Caspnetti.DAL.Enum;

namespace Caspnetti.DAL.Entity;

[Table("ThreadPresences")]
public class ThreadPresence: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ThreadPresenceAction Action { get; set; }

    public virtual User? User { get; set; }

    public ThreadPresence()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
