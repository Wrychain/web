using Caspnetti.DAL.Entity.Stations;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Channels;

public class Channel: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public required string Name { get; set; }

    public required int StationId { get; set; }
    public required Station Station { get; set; }

    public required int CreatorId { get; set; }
    public required User Creator { get; set; }

    public List<ChannelFeed>? ChannelFeeds { get; set; }

    public Channel()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
