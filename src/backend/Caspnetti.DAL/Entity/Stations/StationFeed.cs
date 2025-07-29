using Caspnetti.DAL.Entity.Feeds;

namespace Caspnetti.DAL.Entity.Stations;

public class StationFeed
{
    public int Id { get; set; }

    public int StationId { get; set; }
    public required Station Station { get; set; }

    public int FeedId { get; set; }
    public required Feed Feed { get; set; }
}
