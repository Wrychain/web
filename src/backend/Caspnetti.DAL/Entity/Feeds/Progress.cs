using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Messages;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Feeds;

public class Progress: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int FeedId { get; set; }
    public required Feed Feed { get; set; }
    public int CreatorId { get; set; }
    public required User Creator { get; set; }
    public int LastMessageReadId { get; set; }
    public required Message LastMessageRead { get; set; }

    public Progress()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
