using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Users;
using Caspnetti.DAL.Enum;

namespace Caspnetti.DAL.Entity.Feeds;

public class Presence: IEntity
{
    // Main
    public int Id { get; set; }
    public required int FeedId { get; set; }
    public required int UserId { get; set; }
    public required PresenceAction Action { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public Feed? Feed { get; set; }
    public User? User { get; set; }
}
