using Wrychain.DAL.Entity.Channels;
using Wrychain.DAL.Entity.Messages;
using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Channels;

public class Progress: IEntity
{
    // Main
    public int Id { get; set; }
    public required int ChannelId { get; set; }
    public required int CreatorId { get; set; }
    public required int LastMessageReadId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public required Channel Channel { get; set; }
    public required User Creator { get; set; }
    public required Message LastMessageRead { get; set; }
}
