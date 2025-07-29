namespace Caspnetti.DAL.Entity.Users;

public class LoginSession: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    public string? IPAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? TokenHash { get; set; }

    public bool IsActive { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }

    public LoginSession()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;

        this.IsActive = false;
    }
}
