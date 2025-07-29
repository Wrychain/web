using Caspnetti.DAL.Entity.Feeds;
using Caspnetti.DAL.Entity.Files;
using Caspnetti.DAL.Entity.Stations;

namespace Caspnetti.DAL.Entity.Users;

public class User: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastActiveAt { get; set; }

    public string? Username { get; set; }
    public string? DisplayName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }

    public FilePointer? Avatar { get; set; }
    public FilePointer? Banner { get; set; }

    public List<LoginAttempt>? LoginAttempts { get; set; }
    public List<UserConnection>? Friends { get; set; }
    public List<Notification>? Notifications { get; set; }
    public List<LoginSession>? LoginSessions { get; set; }
    public List<UserVAPID>? VapidSessions { get; set; }
    public List<Feed>? DirectFeeds { get; set; }

    public List<Station>? CreatedStations { get; set; }
    public List<Station>? MemberStations { get; set; }

    public User()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;
    }
}
