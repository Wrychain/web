using Caspnetti.DAL.Entity.Channels;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Stations;

// StationCustomChannel is created after Channel to link via Station::CustomChannels
public class StationCustomChannel: IEntity
{
    // Main
    public int Id { get; set; }
    public required int SortIndex { get; set; }
    public required int UserId { get; set; }
    public required int StationId { get; set; }
    public required int ChannelId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? User { get; set; }
    public Station? Station { get; set; }
    public Channel? Channel { get; set; }
}
