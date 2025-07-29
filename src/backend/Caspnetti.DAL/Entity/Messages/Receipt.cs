using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Messages;

public class Receipt: IEntity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ReadAt { get; set; }

    public int UserId { get; set; }
    public required User User { get; set; }

    public int MessageId { get; set; }
    public required Message Message { get; set; }

    public Receipt()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
    }
}
