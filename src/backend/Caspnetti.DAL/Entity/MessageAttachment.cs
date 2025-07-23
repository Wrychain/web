using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("MessageAttachments")]
public class MessageAttachment: IEntity
{
    public int Id { get; set; }
    
    public virtual File? File { get; set; }
    public virtual User? Author { get; set; }
    public virtual MessageAttachmentType? Type { get; set; }
}
