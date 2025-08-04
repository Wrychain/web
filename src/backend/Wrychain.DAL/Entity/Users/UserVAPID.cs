namespace Wrychain.DAL.Entity.Users;

public class UserVAPID
{
    // Main
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Endpoint { get; set; }
    public string? PublicKey { get; set; }
    public string? PrivateKey { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastUsedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public User? User { get; set; }
}
