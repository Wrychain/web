using Caspnetti.DAL.Entity.Files;
using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Messages;

public class Attachment: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int MessageId { get; set; }
    public required Message Message { get; set; }

    public int FilePointerId { get; set; }
    public required FilePointer FilePointer { get; set; }

    public int? AuthorId { get; set; }
    public User? Author { get; set; }

    public Attachment()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
