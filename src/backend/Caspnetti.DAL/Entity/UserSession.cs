using System.ComponentModel.DataAnnotations.Schema;

namespace Caspnetti.DAL.Entity;

[Table("UserSessions")]
public class UserSession: IEntity
{
    public int Id { get; set; }
    public string? IPAddress { get; set; }
    public string? UserAgent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public bool IsActive { get; set; }
    public string? TokenHash { get; set; }

    public virtual User? User { get; set; }

    public UserSession()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
