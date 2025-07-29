using Caspnetti.DAL.Entity.Stations;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Channels;

public class Channel: IEntity
{
    // Main
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int CreatorId { get; set; }
    public required int StationId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public Station? Station { get; set; }
    public User? Creator { get; set; }
    public List<ChannelFeed>? ChannelFeeds { get; set; }
}
