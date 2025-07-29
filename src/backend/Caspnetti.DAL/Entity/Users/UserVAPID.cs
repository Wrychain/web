namespace Caspnetti.DAL.Entity.Users;

public class UserVAPID
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUsedAt { get; set; }

    public bool IsActive { get; set; }

    public int UserId { get; set; }
    public required User User { get; set; }

    public string? Endpoint { get; set; }
    public string? PublicKey { get; set; }
    public string? PrivateKey { get; set; }

    public UserVAPID()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.LastUsedAt = currentTime;
        this.IsActive = true;
    }
}
