using Caspnetti.DAL.Entity.Files;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Messages;

// Attachment is created, added to a new Message, Message is created
public class Attachment: IEntity
{
    // Main
    public int Id { get; set; }
    public required int AuthorId { get; set; }
    public required int FilePointerId { get; set; }
    public int? MessageId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation
    public Message? Message { get; set; }
    public FilePointer? FilePointer { get; set; }
    public User? Author { get; set; }
}
