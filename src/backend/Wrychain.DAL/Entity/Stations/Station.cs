using Wrychain.DAL.Entity.Feeds;
using Wrychain.DAL.Entity.Invites;
using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Stations;

public class Station: IEntity
{
    // Main
    public int Id { get; set; }
    public required int CreatorId { get; set; }
    public required string Name { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    public User? Creator { get; set; }
    public List<User>? Members { get; set; }
    public List<StationDefaultChannel>? DefaultChannels { get; set; }
    public List<StationCustomChannel>? CustomChannels { get; set; }
    public List<StationUserSetting>? UserSettings { get; set; }
    public List<StationFeed>? GlobalFeeds { get; set; }
    public List<StationInvite>? StationInvites { get; set; }
}
