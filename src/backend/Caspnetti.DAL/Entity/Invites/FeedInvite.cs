using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Stations;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Invites;

public class FeedInvite: IEntity
{
    // Main
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public int FeedId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? Sender { get; set; }
    public User? Receiver { get; set; }
    public Feed? Feed { get; set; }
}
