using Wrychain.DAL.Entity.Channels;
using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Stations;

public class StationDefaultChannel: IEntity
{
    // Main
    public int Id { get; set; }
    public required int SortIndex { get; set; }
    public required int StationId { get; set; }
    public required int ChannelId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation
    public Station? Station { get; set; }
    public Channel? Channel { get; set; }
}
