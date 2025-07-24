using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("MessageReactions")]
public class MessageReaction: IEntity
{
    public int Id { get; set; }
    public string? Reaction { get; set; }
    public DateTime? CreatedAt { get; set; }

    public virtual User? From { get; set; }

    public MessageReaction()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
    }
}
