using Caspnetti.DAL.Entity.Stations;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Invites;

public class StationInvite: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int? SenderId { get; set; }
    public User? Sender { get; set; }
    public int? ReceiverId { get; set; }
    public User? Receiver { get; set; }
    public int? StationId { get; set; }
    public Station? Station { get; set; }

    public StationInvite()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
