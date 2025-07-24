using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("MessageAttachments")]
public class MessageAttachment: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual File? File { get; set; }
    public virtual User? Author { get; set; }

    public MessageAttachment()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
