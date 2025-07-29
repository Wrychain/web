using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Messages;

public class Message: IEntity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string? Text { get; set; }

    public int? AuthorId { get; set; }
    public User? Author { get; set; }

    public List<Attachment>? Attachments { get; set; }
    public List<Reaction>? Reactions { get; set; }
    public List<Receipt>? Receipts { get; set; }

    public Message()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
