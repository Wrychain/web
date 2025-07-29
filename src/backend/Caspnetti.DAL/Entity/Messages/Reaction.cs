using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Messages;

public class Reaction: IEntity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }

    public string? Text { get; set; }

    public int? FromId { get; set; }
    public User? From { get; set; }

    public Reaction()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
    }
}
