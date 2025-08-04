using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Invites;

public class FriendInvite: IEntity
{
    // Main
    public int Id { get; set; }
    public required int SenderId { get; set; }
    public required int ReceiverId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? Sender { get; set; }
    public User? Receiver { get; set; }
}
