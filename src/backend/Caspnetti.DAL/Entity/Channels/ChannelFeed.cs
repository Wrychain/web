using Caspnetti.DAL.Entity.Channels;
using Caspnetti.DAL.Entity.Feeds;

namespace Caspnetti.DAL.Entity.Channels;

public class ChannelFeed: IEntity
{
    public int Id { get; set; }

    public int SortIndex { get; set; }

    public int ChannelId { get; set; }
    public required Channel Channel { get; set; }
    public int FeedId { get; set; }
    public required Feed Feed { get; set; }
}
