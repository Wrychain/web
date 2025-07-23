using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("Users")]
public class User: IEntity
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public virtual ICollection<UserToken> Tokens { get; set; }
    public virtual ICollection<UserSession> Sessions { get; set; }
}
