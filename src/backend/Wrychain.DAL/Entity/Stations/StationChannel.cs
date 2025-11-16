using Wrychain.DAL.Entity.Channels;

namespace Wrychain.DAL.Entity.Stations;

// Join entity to enable Station::GlobalChannels
public class StationChannel
{
    // Main
    public int Id { get; set; }
    public required int StationId { get; set; }
    public required int ChannelId { get; set; }

    // Navigation
    public Station? Station { get; set; }
    public Channel? Channel { get; set; }
}
