using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("Messages")]
public class Message: IEntity
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public virtual User? Author { get; set; }
    public virtual ICollection<MessageAttachment>? Attachments { get; set; }
    public virtual ICollection<MessageReaction>? Reactions { get; set; }
    public virtual ICollection<MessageReceipt>? Receipts { get; set; }

    public Message()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
