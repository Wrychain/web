using Caspnetti.DAL.Entity.Stations;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Invites;

public class PlatformInvite: IEntity
{
    // Main
    public int Id { get; set; }
    public required int SenderId { get; set; }
    public required string TokenHash { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime ExpiresAt { get; set; } = DateTime.Now.AddDays(1);
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? Sender { get; set; }
}
