# Enum++ for sent, delivered, read
# Creates N entries

using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("MessageReceipts")]
public class MessageReceipt: IEntity
{
    public int Id { get; set; }

    public virtual Message? Message { get; set; }
    public virtual User? By { get; set; }
}
