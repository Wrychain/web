using Caspnetti.DAL.Entity.Channels;
using Caspnetti.DAL.Entity.Feeds;

namespace Caspnetti.DAL.Entity.Channels;

// One to one join between Channel and Feed w/ SortIndex
public class ChannelFeed: IEntity
{
    // Main
    public int Id { get; set; }
    public required int SortIndex { get; set; }
    public required int ChannelId { get; set; }
    public required int FeedId { get; set; }

    // Navigation
    public Channel? Channel { get; set; }
    public Feed? Feed { get; set; }
}
