using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("MessageReceipts")]
public class MessageReceipt: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual User? By { get; set; }

    public MessageReceipt()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
    }
}
