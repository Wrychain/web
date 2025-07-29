namespace Caspnetti.DAL.Entity.Users;

// Created when an email/2FA token is sent/expected from user.
// IsActive updated with successful TokenHash validation.
public class LoginSession: IEntity
{
    // Main
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required string TokenHash { get; set; }
    public string? IPAddress { get; set; }
    public string? UserAgent { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? ExpiresAt { get; set; } = DateTime.Now.AddDays(7);
    public bool IsActive { get; set; } = false;

    // Navigation
    public User? User { get; set; }
}
