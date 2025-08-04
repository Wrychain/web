using Wrychain.DAL.Entity.Feeds;
using Wrychain.DAL.Entity.Files;
using Wrychain.DAL.Entity.Stations;

namespace Wrychain.DAL.Entity.Users;

public class User: IEntity
{
    // Main
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string DisplayName { get; set; }
    public string? Email { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime LastActiveAt { get; set; } = DateTime.Now;

    // Navigation
    public FilePointer? Avatar { get; set; }
    public FilePointer? Banner { get; set; }
    public List<LoginAttempt>? LoginAttempts { get; set; }
    public List<UserConnection>? Friends { get; set; }
    public List<Notification>? Notifications { get; set; }
    public List<LoginSession>? LoginSessions { get; set; }
    public List<UserVAPID>? VapidSessions { get; set; }
    public List<Feed>? DirectFeeds { get; set; }
    public List<Station>? CreatedStations { get; set; }
    public List<Station>? JoinedStations { get; set; }
}
