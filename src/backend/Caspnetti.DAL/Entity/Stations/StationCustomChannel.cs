using Caspnetti.DAL.Entity.Channels;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Stations;

public class StationCustomChannel: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int SortIndex { get; set; }

    public int StationId { get; set; }
    public required Station Station { get; set; }

    public int? UserId { get; set; }
    public required User? User { get; set; }

    public int ChannelId { get; set; }
    public required Channel Channel { get; set; }

    public StationCustomChannel()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
