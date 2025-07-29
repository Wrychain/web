using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Feeds;

public class Feed: IEntity
{
    // Main
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int CreatorId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? Creator { get; set; }
    public List<FeedReader>? Readers { get; set; }
    public List<FeedWriter>? Writers { get; set; }
    public List<Presence>? Presences { get; set; }
    public List<Progress>? Progresses { get; set; }
}
