using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Messages;

// User views an existing message, creates this receipt, and adds it to the message context
public class Receipt: IEntity
{
    // Main
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int MessageId { get; set; }

    // Meta
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    // Navigation
    public User? User { get; set; }
    public Message? Message { get; set; }
}
