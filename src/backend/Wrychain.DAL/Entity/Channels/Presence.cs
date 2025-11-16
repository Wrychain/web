using Wrychain.DAL.Entity.Channels;
using Wrychain.DAL.Entity.Users;
using Wrychain.DAL.Enum;

namespace Wrychain.DAL.Entity.Channels;

public class Presence: IEntity
{
    // Main
    public int Id { get; set; }
    public required int ChannelId { get; set; }
    public required int UserId { get; set; }
    public required PresenceAction Action { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public Channel? Channel { get; set; }
    public User? User { get; set; }
}
