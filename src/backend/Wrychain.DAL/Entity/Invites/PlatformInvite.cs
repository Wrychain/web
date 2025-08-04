using Wrychain.DAL.Entity.Stations;
using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Invites;

public class PlatformInvite: IEntity
{
    // Main
    public int Id { get; set; }
    public required int SenderId { get; set; }
    public required string TokenHash { get; set; }
    public int? ReceiverId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime ExpiresAt { get; set; } = DateTime.Now.AddDays(1);
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? Sender { get; set; }
    public User? Receiver { get; set; }
}
