using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Feeds;

public class Feed: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public required string Name { get; set; }
    public required int CreatorId { get; set; }
    public required User Creator { get; set; }

    public List<FeedReader>? Readers { get; set; }
    public List<FeedWriter>? Writers { get; set; }
    public List<Presence>? Presences { get; set; }
    public List<Progress>? Progresses { get; set; }

    public Feed()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
