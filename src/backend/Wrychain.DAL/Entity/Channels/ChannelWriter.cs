using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Channels;

public class ChannelWriter: IEntity
{
    // Main
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int ChannelId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? User { get; set; }
    public Channel? Channel { get; set; }
}
