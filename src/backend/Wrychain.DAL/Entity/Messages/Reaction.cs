using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Messages;

public class Reaction: IEntity
{
    // Main
    public int Id { get; set; }
    public required int FromId { get; set; }
    public required string Text { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation
    public User? From { get; set; }
}
