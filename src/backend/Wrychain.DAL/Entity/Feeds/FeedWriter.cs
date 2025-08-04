using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Feeds;

public class FeedWriter: IEntity
{
    // Main
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int FeedId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? User { get; set; }
    public Feed? Feed { get; set; }
}
