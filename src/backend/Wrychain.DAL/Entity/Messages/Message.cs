using Wrychain.DAL.Entity.Users;

namespace Wrychain.DAL.Entity.Messages;

public class Message: IEntity
{
    // Main
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string? Text { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? Author { get; set; }
    public List<Attachment>? Attachments { get; set; }
    public List<Reaction>? Reactions { get; set; }
    public List<Receipt>? Receipts { get; set; }
}
