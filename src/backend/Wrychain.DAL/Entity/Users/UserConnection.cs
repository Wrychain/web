using Wrychain.DAL.Enum;

namespace Wrychain.DAL.Entity.Users;

public class UserConnection: IEntity
{
    // Main
    public int Id { get; set; }
    public required int FriendId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? Friend { get; set; }
}
