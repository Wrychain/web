using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("Notifications")]
public class Notification: IEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ReadAt { get; set; }

    public Notification()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
    }
}
