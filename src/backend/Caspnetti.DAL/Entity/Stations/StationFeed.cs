using Caspnetti.DAL.Entity.Feeds;

namespace Caspnetti.DAL.Entity.Stations;

// Join entity to enable Station::GlobalFeeds
public class StationFeed
{
    // Main
    public int Id { get; set; }
    public required int StationId { get; set; }
    public required int FeedId { get; set; }

    // Navigation
    public Station? Station { get; set; }
    public Feed? Feed { get; set; }
}
