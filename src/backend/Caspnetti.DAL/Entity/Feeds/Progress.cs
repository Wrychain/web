using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Messages;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Feeds;

public class Progress: IEntity
{
    // Main
    public int Id { get; set; }
    public required int FeedId { get; set; }
    public required int CreatorId { get; set; }
    public required int LastMessageReadId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public required Feed Feed { get; set; }
    public required User Creator { get; set; }
    public required Message LastMessageRead { get; set; }
}
