using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Feeds;

public class FeedWriter: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int UserId { get; set; }
    public required User User { get; set; }
    public int FeedId { get; set; }
    public required Feed Feed { get; set; }

    public bool IsActive { get; set; }

    public FeedWriter()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
