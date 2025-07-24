using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Caspnetti.DAL.Enum;

namespace Caspnetti.DAL.Entity;

[Table("Users")]
[Index(nameof(Email), IsUnique = true)]
public class User: IEntity
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? DisplayName { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public Role? Role { get; set; }

    public virtual ICollection<UserSession>? Sessions { get; set; }
    public virtual ICollection<User>? Friends { get; set; }
    public virtual ICollection<Notification>? Notifications { get; set; }

    public User()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
    }
}
