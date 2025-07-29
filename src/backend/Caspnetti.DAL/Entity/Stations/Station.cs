using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Stations;

public class Station: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public required string Name { get; set; }
    public required int CreatorId { get; set; }

    public User? Creator { get; set; }
    public List<User>? Members { get; set; }
    public List<StationDefaultChannel>? DefaultChannels { get; set; }
    public List<StationCustomChannel>? CustomChannels { get; set; }
    public List<StationUserSetting>? UserSettings { get; set; }
    public List<StationFeed>? StationFeeds { get; set; }

    public Station()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
