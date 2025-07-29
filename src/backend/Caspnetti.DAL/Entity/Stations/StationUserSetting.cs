using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Stations;

public class StationUserSetting: IEntity
{
    // Main
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }
    public required int UserId { get; set; }
    public required int StationId { get; set; }

    // Meta
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Navigation
    public Station? Station { get; set; }
    public User? User { get; set;}
}
