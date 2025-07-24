// Store the context of the last message a user has seen for purposes of determining what is unread.

// Relates one thread to one message. Determine update logic/flow in the future

using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("ThreadProgresses")]
public class ThreadProgress: IEntity
{
    public int Id { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual User? User { get; set; }
    public virtual Message? LastReadMessage { get; set; }

    public ThreadProgress()
    {
        var currentTime = DateTime.Now;
        this.UpdatedAt = currentTime;
    }
}
