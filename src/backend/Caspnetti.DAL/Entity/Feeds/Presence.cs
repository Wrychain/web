using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Users;
using Caspnetti.DAL.Enum;

namespace Caspnetti.DAL.Entity.Feeds;

public class Presence: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int FeedId { get; set; }
    public required Feed Feed { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public PresenceAction Action { get; set; }

    public bool IsActive { get; set; }

    public Presence()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;

        this.IsActive = true;
    }
}
