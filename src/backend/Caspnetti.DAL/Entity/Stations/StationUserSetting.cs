using Caspnetti.DAL.Entity.Users;

namespace Caspnetti.DAL.Entity.Stations;

public class StationUserSetting: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public required string Name { get; set; }
    public required string Value { get; set; }
    public bool IsActive { get; set; }

    public int StationId { get; set; }
    public required Station Station { get; set; }

    public int UserId { get; set; }
    public required User User { get; set;}

    public StationUserSetting()
    {
        var currentTime = DateTime.Now;
        this.CreatedAt = currentTime;
        this.UpdatedAt = currentTime;

        this.IsActive = true;
    }
}
