using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("ThreadOrderings")]
public class ThreadOrdering: IEntity
{
    public int Id { get; set; }
    public int Index { get; set; }

    public virtual required Thread? Thread { get; set; }
}
