using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Stations;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Invites;

public class FeedInvite: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int? SenderId { get; set; }
    public User? Sender { get; set; }
    public int? ReceiverId { get; set; }
    public User? Receiver { get; set; }
    public int? FeedId { get; set; }
    public Feed? Feed { get; set; }

    public FeedInvite()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
