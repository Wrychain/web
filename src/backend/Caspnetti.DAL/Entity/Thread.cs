using System.ComponentModel.DataAnnotations.Schema;
using Caspnetti.DAL.Enum;

namespace Caspnetti.DAL.Entity;

[Table("Threads")]
public class Thread: IEntity
{
    public int Id { get; set; }
    public ThreadType ThreadType { get; set; }

    public virtual required User? Creator { get; set; }
    public virtual required ICollection<User> Users { get; set; }
    public virtual ICollection<Message>? Messages { get; set; }
    public virtual ICollection<ThreadProgress>? ThreadProgresses { get; set; }
    public virtual ICollection<ThreadPresence>? ThreadPresences { get; set; }
}
